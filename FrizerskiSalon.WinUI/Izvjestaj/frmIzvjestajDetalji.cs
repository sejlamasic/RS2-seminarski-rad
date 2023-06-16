using System;
using System.Windows.Forms;

namespace FrizerskiSalon.WinUI.Izvjestaj
{
    public partial class frmIzvjestajDetalji : Form
    {
        private Modal.Izvjestaj _izvjestaj;
        public frmIzvjestajDetalji(Modal.Izvjestaj izvjestaj = null)
        {
            InitializeComponent();
            _izvjestaj = izvjestaj;
            WindowState = FormWindowState.Maximized;
        }

        private void frmIzvjestajDetalji_Load(object sender, EventArgs e)
        {
            if (_izvjestaj != null)
            {
                txtDatum.Text = _izvjestaj.Datum.ToString();
                txtDetalji.Text = _izvjestaj.Detalji;
            }
        }
    }
}
