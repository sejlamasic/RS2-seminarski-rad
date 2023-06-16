using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrizerskiSalon.Modal;
using FrizerskiSalon.Modal.SearchObjects;

namespace FrizerskiSalon.WinUI.Klijent
{
    public partial class frmPrikazKlijenata : Form
    {
        APIService _klijentService = new APIService("Klijent");
        APIService _spolService = new APIService("Spol");
        public frmPrikazKlijenata()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            //dgvKlijenti.AutoGenerateColumns = true;
        }

        private async void btnPrikazi_Click(object sender, EventArgs e)
        {
            try
            {
                var search = new KlijentSearchObject()
                {
                    Ime = txtIme.Text,
                    Prezime = txtPrezime.Text,
                    SpolId = (int)cmbSpol.SelectedValue
                };
                var list = await _klijentService.Get<IList<Modal.Klijent>>(search);
                dgvKlijenti.DataSource = null;
                dgvKlijenti.DataSource = list;
                dgvKlijenti.Columns[6].Visible = false;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void frmPrikazKlijenata_Load(object sender, EventArgs e)
        {
            try
            {
                await LoadSpol();
                dgvKlijenti.DataSource = null;
                dgvKlijenti.DataSource = await _klijentService.Get<IList<Modal.Klijent>>(null);
                dgvKlijenti.Columns[6].Visible = false;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async Task LoadSpol()
        {
            try
            {
                var spolovi = await _spolService.Get<List<Spol>>(null);
                cmbSpol.DataSource = spolovi;
                cmbSpol.ValueMember = "SpolId";
                cmbSpol.DisplayMember = "Naziv";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
