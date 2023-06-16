﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrizerskiSalon.Modal;
using FrizerskiSalon.Modal.Requests;

namespace FrizerskiSalon.WinUI.Proizvod
{
    public partial class frmProizvodDetalji : Form
    {
        APIService _proizvodiService = new APIService("Proizvod");
        APIService _tipProizvodaService = new APIService("TipProizvodum");

        private Modal.Proizvod _proizvod;
        public frmProizvodDetalji(Modal.Proizvod proizvod = null)
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            _proizvod = proizvod;
        }

        private async void frmProizvodDetalji_Load(object sender, EventArgs e)
        {
            await LoadTipProizvoda();
            if (_proizvod != null)
            {
                txtNaziv.Text = _proizvod.Naziv;
                txtCijena.Text = _proizvod.Cijena.ToString();
                cmbTipProizvoda.SelectedValue = _proizvod.TipProizvodaId;
                txtOpis.Text = _proizvod.Opis;
                txtPutanjaDoSlike.Text = ConvertBytesToString((Byte[])_proizvod.Slika);
                if (File.Exists(txtPutanjaDoSlike.Text))
                {
                    pcbSlika.Image = Image.FromFile(txtPutanjaDoSlike.Text);
                }
            }
        }

        private async Task LoadTipProizvoda()
        {
            try
            {
                var tipProizvoda = await _tipProizvodaService.Get<List<TipProizvodum>>(null);
                cmbTipProizvoda.DisplayMember = "Naziv";
                cmbTipProizvoda.ValueMember = "TipProizvodaId";
                cmbTipProizvoda.DataSource = tipProizvoda;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private async void btnSpremi_Click(object sender, EventArgs e)
        {
            if (ValidirajUnos())
            {
                try
                {
                    var request = new ProizvodInsertRequest()
                    {
                        Naziv = txtNaziv.Text,
                        Cijena = Double.Parse(txtCijena.Text),
                        Opis = txtOpis.Text,
                        TipProizvodaId = (int)cmbTipProizvoda.SelectedValue,
                        Slika = Encoding.ASCII.GetBytes(txtPutanjaDoSlike.Text)
                    };

                    MemoryStream ms = new MemoryStream();
                    pcbSlika.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    byte[] buff = ms.GetBuffer();
                    request.Slika = buff;
                    byte[] slikaBytes = Encoding.ASCII.GetBytes(txtPutanjaDoSlike.Text);
                    MemoryStream stream = new MemoryStream(slikaBytes);
                    request.Slika = stream.ToArray();
                    if (_proizvod == null)
                    {
                        await _proizvodiService.Insert<Modal.Proizvod>(request, "relative/route");
                    }
                    else
                    {
                        await _proizvodiService.Update<Modal.Proizvod>(_proizvod.ProizvodId, request);
                    }
                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private async void btnObrisi_Click(object sender, EventArgs e)
        {
            try
            {
                if (_proizvod != null)
                {
                    DialogResult dialogResult = MessageBox.Show("Da li ste sigurni?", "Upozorenje", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        await _proizvodiService.Delete(_proizvod.ProizvodId);
                        Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                    txtPutanjaDoSlike.Text = fileName;
                    var file = File.ReadAllBytes(fileName);
                    pcbSlika.Image = Image.FromFile(fileName);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static string ConvertBytesToString(byte[] bytes)
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
            return Validator.ObaveznoPolje(txtNaziv, err, Validator.poruka) &&
                Validator.ObaveznoPolje(txtCijena, err, Validator.poruka) &&
                Validator.IntegerPolje(txtCijena, err, Validator.intpolje) &&
                Validator.ObaveznoPolje(txtPutanjaDoSlike, err, Validator.poruka) &&
                Validator.ObaveznoPolje(txtOpis, err, Validator.poruka) &&
                Validator.MinDuzina(txtNaziv, err, 3, Validator.minDuzina) &&
                Validator.MaxDuzina(txtNaziv, err, 35, Validator.maxDuzina) &&
                Validator.MinDuzina(txtOpis, err, 3, Validator.minDuzina) &&
                Validator.MaxDuzina(txtOpis, err, 40, Validator.maxDuzina);
        }
    }
}
