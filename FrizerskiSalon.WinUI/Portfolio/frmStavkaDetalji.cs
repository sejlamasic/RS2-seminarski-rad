﻿using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using FrizerskiSalon.Modal.Requests;

namespace FrizerskiSalon.WinUI.Portfolio
{
    public partial class frmStavkaDetalji : Form
    {
        APIService _stavkePortfoliumService = new APIService("StavkePortfolium");
        private Modal.StavkePortfolium _stavkePortfolium;
        public frmStavkaDetalji(Modal.StavkePortfolium stavkePortfolium = null)
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            _stavkePortfolium = stavkePortfolium;
        }

        private void frmStavkaDetalji_Load(object sender, EventArgs e)
        {
            if (_stavkePortfolium != null)
            {
                dtpDatum.Value = (DateTime)_stavkePortfolium.Datum;
                txtOpis.Text = _stavkePortfolium.Opis;
                txtSlika.Text = ConvertBytesToString((Byte[])_stavkePortfolium.Slika);
                if (File.Exists(txtSlika.Text))
                {
                    pcbSlika.Image = Image.FromFile(txtSlika.Text);
                }
            }

        }

        private void btnUcitajSliku_Click(object sender, EventArgs e)
        {
            try
            {
                var result = ofdSlika.ShowDialog();
                if (result == DialogResult.OK)
                {
                    var fileName = ofdSlika.FileName;
                    txtSlika.Text = fileName;
                    var file = File.ReadAllBytes(fileName);
                    pcbSlika.Image = Image.FromFile(fileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void btnObrisi_Click(object sender, EventArgs e)
        {
            try
            {
                if (_stavkePortfolium != null)
                {
                    DialogResult dialogResult = MessageBox.Show("Da li ste sigurni?", "Upozorenje", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        await _stavkePortfoliumService.Delete(_stavkePortfolium.StavkaPortfoliaId);
                        Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void btnSnimi_Click(object sender, EventArgs e)
        {
            if (ValidirajUnos())
            {
                try
                {
                    var request = new StavkePortfoliumInsertRequest
                    {
                        Datum = dtpDatum.Value,
                        Opis = txtOpis.Text,
                        Slika = Encoding.ASCII.GetBytes(txtSlika.Text),
                        PortfolioId = Global.portfolioPrijavljenogUposlenika.PortfolioId
                    };
                    MemoryStream ms = new MemoryStream();
                    pcbSlika.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    byte[] buff = ms.GetBuffer();
                    request.Slika = buff;
                    byte[] slikaBytes = Encoding.ASCII.GetBytes(txtSlika.Text);
                    MemoryStream stream = new MemoryStream(slikaBytes);
                    request.Slika = stream.ToArray();
                    if (_stavkePortfolium == null)
                    {
                        await _stavkePortfoliumService.Insert<Modal.StavkePortfolium>(request);
                    }
                    else
                    {
                        //request.PortfolioId = Global.portfolioPrijavljenogUposlenika.PortfolioId;
                        await _stavkePortfoliumService.Update<Modal.StavkePortfolium>(_stavkePortfolium.StavkaPortfoliaId, request);
                    }
                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private string ConvertBytesToString(byte[] bytes)
        {
            string output = String.Empty;
            MemoryStream stream = new MemoryStream(bytes);
            stream.Position = 0;
            StreamReader reader = new StreamReader(stream);
            output = reader.ReadToEnd();
            return output;
        }
        private bool ValidirajUnos()
        {
            return Validator.ObaveznoPolje(txtOpis, err, Validator.poruka) &&
                Validator.MaxDuzina(txtOpis, err, 100, Validator.maxDuzina) &&
                Validator.ObaveznoPolje(txtSlika, err, Validator.poruka);
        }
    }
}
