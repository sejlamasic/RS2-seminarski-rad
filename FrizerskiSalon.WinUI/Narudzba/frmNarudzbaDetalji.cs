using System;
using System.Collections.Generic;
using System.Windows.Forms;
using FrizerskiSalon.Modal.Requests;
using FrizerskiSalon.Modal.SearchObjects;

namespace FrizerskiSalon.WinUI.Narudzba
{
    public partial class frmNarudzbaDetalji : Form
    {
        APIService _stavkeNarudzbeService = new APIService("StavkeNarudzbe");
        APIService _narudzbaService = new APIService("Narudzba");
        APIService _klijentService = new APIService("Klijent");

        private Modal.Narudzba _narudzba;
        private Modal.Klijent _klijent;
        public frmNarudzbaDetalji(Modal.Narudzba narudzba = null)
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            _narudzba = narudzba;
        }

        private async void frmNarudzbaDetalji_Load(object sender, EventArgs e)
        {
            try
            {
                if (_narudzba != null)
                {
                    _klijent = await _klijentService.GetById<Modal.Klijent>(_narudzba.KlijentId);
                    txtImePrezime.Text = _klijent.Ime + " " + _klijent.Prezime;
                    txtKorisnickoIme.Text = _klijent.KorisnickoIme;
                    txtDatum.Text = _narudzba.Datum.ToString();
                    txtUkupniIznos.Text = _narudzba.UkupniIznos.ToString();
                    chbPlacena.Checked = _narudzba.IsPlacena.Value;
                    chbIsIsporucena.Checked = _narudzba.IsIsporucena.Value;
                    var request = new StavkeNarudzbeSearchObject()
                    {
                        NarudzbaId = _narudzba.NarudzbaId
                    };
                    dgvStavkeNarudzbe.DataSource = null;
                    dgvStavkeNarudzbe.DataSource = await _stavkeNarudzbeService.Get<IList<Modal.StavkeNarudzbe>>(request);
                    dgvStavkeNarudzbe.Columns[0].Visible = false;
                    dgvStavkeNarudzbe.Columns[1].Visible = false;
                    dgvStavkeNarudzbe.Columns["Narudzba"].Visible = false;
                    dgvStavkeNarudzbe.Columns[4].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void chbIsIsporucena_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (_narudzba.IsPlacena == true)
                {
                    var request = new NarudzbaInsertRequest()
                    {
                        IsIsporucena = chbIsIsporucena.Checked,
                        Datum = _narudzba.Datum,
                        KlijentId = _narudzba.KlijentId,
                        //StavkeNarudzbes = _narudzba.StavkeNarudzbes,
                        UkupniIznos = _narudzba.UkupniIznos,
                        IsPlacena = _narudzba.IsPlacena
                    };
                    await _narudzbaService.Update<Modal.Narudzba>(_narudzba.NarudzbaId, request);
                    //Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
