﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrizerskiSalon.Modal;
using FrizerskiSalon.Modal.Requests;

namespace FrizerskiSalon.WinUI.LoginRegistracija
{
    public partial class frmRegistracija : Form
    {
        APIService _uposlenikService = new APIService("Uposlenik");
        APIService _spolService = new APIService("Spol");
        APIService _zanimanjeService = new APIService("Zanimanje");
        public frmRegistracija()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
        }
        private async Task LoadSpol()
        {
            try
            {
                var spolovi = await _spolService.Get<List<Spol>>(null);
                cmbSpol.DataSource = spolovi;
                cmbSpol.DisplayMember = "Naziv";
                cmbSpol.ValueMember = "SpolId";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private async Task LoadZanimanje()
        {
            try
            {
                var zanimanja = await _zanimanjeService.Get<List<Zanimanje>>(null);
                cmbZanimanje.DataSource = zanimanja;
                cmbZanimanje.DisplayMember = "Naziv";
                cmbZanimanje.ValueMember = "ZanimanjeId";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void btnRegistracija_Click(object sender, EventArgs e)
        
        {
            if (ValidirajUnos())
            {
                try
                {
                    var uposlenik = new UposlenikInsertRequest()
                    {
                        Ime = txtIme.Text,
                        Prezime = txtPrezime.Text,
                        KorisnickoIme = txtKorisnickoIme.Text,
                        Lozinka = txtLozinka.Text,
                        PotvrdiLozinku = txtPotvrdaLozinke.Text,
                        Email = txtEmail.Text,
                        Telefon = txtTelefon.Text,
                        SpolId = (int)cmbSpol.SelectedValue,
                        ZanimanjeId = (int)cmbZanimanje.SelectedValue
                    };
                    byte[] slikaBytes = Encoding.ASCII.GetBytes(txtPutanjaDoSlike.Text);
                    MemoryStream stream = new MemoryStream(slikaBytes);
                    uposlenik.Slika = stream.ToArray();
                    Global.prijavljeniUposlenik = await _uposlenikService.Insert<Uposlenik>(uposlenik);
                    MessageBox.Show("Uspješno izvršena registracija", "Registracija", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                    frmPrijava frm = new frmPrijava();
                    frm.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private async void frmRegistracija_Load(object sender, EventArgs e)
        {
            await LoadSpol();
            await LoadZanimanje();
        }

        private bool ValidirajUnos()
        {
            return Validator.ObaveznoPolje(txtIme, err, Validator.poruka) &&
                Validator.MinDuzina(txtIme, err, 3, Validator.minDuzina) &&
                Validator.MaxDuzina(txtIme, err, 20, Validator.minDuzina) &&
                //Validator.SamoSlova(txtIme, err, Validator.samoSlova) &&
                Validator.ObaveznoPolje(txtPrezime, err, Validator.poruka) &&
                Validator.MinDuzina(txtPrezime, err, 3, Validator.minDuzina) &&
                Validator.MaxDuzina(txtPrezime, err, 30, Validator.minDuzina) &&
                //Validator.SamoSlova(txtPrezime, err, Validator.samoSlova) &&
                Validator.ObaveznoPolje(txtKorisnickoIme, err, Validator.poruka) &&
                Validator.ObaveznoPolje(txtLozinka, err, Validator.poruka) &&
                Validator.ObaveznoPolje(txtPotvrdaLozinke, err, Validator.poruka) &&
                Validator.LozinkePolje(txtLozinka, txtPotvrdaLozinke, err, Validator.lozinke) &&
                Validator.EmailPolje(txtEmail, err, Validator.email) &&
                Validator.TelefonPolje(txtTelefon, err, Validator.telefon) &&
                Validator.ObaveznoPolje(txtPutanjaDoSlike, err, Validator.poruka);
        }

        private void btnUcitajSliku_Click(object sender, EventArgs e)
        {
            try
            {
                var result = ofdSlika.ShowDialog();
                if (result == DialogResult.OK)
                {
                    var fileName = ofdSlika.FileName;
                    txtPutanjaDoSlike.Text = fileName;
                    var file = File.ReadAllBytes(fileName);
                    //result.Slika = File.ReadAllBytes(fileName);
                    Image orgImage = Image.FromFile(fileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        
        {
                this.Close();

                frmHomePage frm = new frmHomePage();
                frm.Show();
            }
    }
}
