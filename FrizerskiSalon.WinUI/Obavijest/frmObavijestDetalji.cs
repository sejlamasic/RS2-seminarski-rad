﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrizerskiSalon.Modal.Requests;

namespace FrizerskiSalon.WinUI.Obavijest
{
    public partial class frmObavijestDetalji : Form
    {
        APIService _obavijestService = new APIService("Obavijest");
        private Modal.Obavijest _obavijest;
        public frmObavijestDetalji(Modal.Obavijest obavijest = null)
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            _obavijest = obavijest;
        }
        private void frmObavijestDetalji_Load(object sender, EventArgs e)
        {
            if (_obavijest != null)
            {
                txtNaslov.Text = _obavijest.Naslov;
                txtSadrzaj.Text = _obavijest.Sadrzaj;
            }
        }

        private async void btnObrisi_Click(object sender, EventArgs e)
        {
            if (_obavijest?.UposlenikId == null ? false : _obavijest.UposlenikId != Global.prijavljeniUposlenik.UposlenikId)
            {
                MessageBox.Show("Nije moguće obrisati obavijesti drugih autora.");
            }
            else
            {
                try
                {
                    if (_obavijest != null)
                    {
                        DialogResult dialogResult = MessageBox.Show("Da li ste sigurni?", "Upozorenje", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            await _obavijestService.Delete(_obavijest.ObavijestId);
                            Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private async void btnSnimi_Click(object sender, EventArgs e)
        {
            if (_obavijest?.UposlenikId == null ? false : _obavijest.UposlenikId != Global.prijavljeniUposlenik.UposlenikId)
            {
                MessageBox.Show("Nije moguće uređivati obavijesti drugih autora.");
            }
            else
            {
                if (ValidirajUnos())
                {
                    try
                    {
                        if (_obavijest == null)
                        {
                            var request = new ObavijestInsertRequest()
                            {
                                Naslov = txtNaslov.Text,
                                Sadrzaj = txtSadrzaj.Text,
                                UposlenikId = Global.prijavljeniUposlenik.UposlenikId,
                                Datum = DateTime.Now
                            };
                            await _obavijestService.Insert<Modal.Obavijest>(request);
                        }
                        else
                        {
                            var request = new ObavijestUpdateRequest()
                            {
                                Naslov = txtNaslov.Text,
                                Sadrzaj = txtSadrzaj.Text
                            };
                            await _obavijestService.Update<Modal.Obavijest>(_obavijest.ObavijestId, request);
                        }
                        Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private bool ValidirajUnos()
        {
            return Validator.ObaveznoPolje(txtNaslov, err, Validator.poruka) &&
                Validator.MinDuzina(txtNaslov, err, 3, Validator.minDuzina) &&
                Validator.MaxDuzina(txtNaslov, err, 50, Validator.maxDuzina) &&
                Validator.ObaveznoPolje(txtSadrzaj, err, Validator.poruka) &&
                Validator.MinDuzina(txtSadrzaj, err, 3, Validator.minDuzina) &&
                Validator.MaxDuzina(txtSadrzaj, err, 500, Validator.maxDuzina);
        }
    }
}
