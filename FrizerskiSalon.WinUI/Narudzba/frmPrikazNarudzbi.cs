using System;
using System.Collections.Generic;
using System.Windows.Forms;
using FrizerskiSalon.Modal.SearchObjects;

namespace FrizerskiSalon.WinUI.Narudzba
{
    public partial class frmPrikazNarudzbi : Form
    {
        APIService _narudzbaService = new APIService("Narudzba");
        public frmPrikazNarudzbi()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
        }

        private async void frmPrikazNarudzbi_Load(object sender, EventArgs e)
        {
            try
            {
                dgvNarudzbe.DataSource = null;
                dgvNarudzbe.DataSource = await _narudzbaService.Get<IList<Modal.Narudzba>>(null);
                dgvNarudzbe.Columns[1].Visible = false;
                dgvNarudzbe.Columns[6].Visible = false;
                dgvNarudzbe.Columns[5].Visible = false;
                dgvNarudzbe.Columns[7].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvNarudzbe_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var item = dgvNarudzbe.SelectedRows[0].DataBoundItem;
            frmNarudzbaDetalji frm = new frmNarudzbaDetalji(item as Modal.Narudzba);
            frm.Show();
        }

        private async void chbIsIsporucena_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chbIsIsporucena.Checked && chbIsPlacena.Checked)
                {
                    var request = new NarudzbaSearchObject()
                    {
                        IsIsporucena = true,
                        IsPlacena = true
                    };
                    dgvNarudzbe.DataSource = null;
                    dgvNarudzbe.DataSource = await _narudzbaService.Get<IList<Modal.Narudzba>>(request);
                    dgvNarudzbe.Columns[1].Visible = false;
                    dgvNarudzbe.Columns[6].Visible = false;
                    dgvNarudzbe.Columns[5].Visible = false;
                    dgvNarudzbe.Columns[7].Visible = false;
                }
                else if (chbIsIsporucena.Checked && !chbIsPlacena.Checked)
                {
                    var request = new NarudzbaSearchObject()
                    {
                        IsIsporucena = true
                    };
                    dgvNarudzbe.DataSource = null;
                    dgvNarudzbe.DataSource = await _narudzbaService.Get<IList<Modal.Narudzba>>(request);
                    dgvNarudzbe.Columns[1].Visible = false;
                    dgvNarudzbe.Columns[6].Visible = false;
                    dgvNarudzbe.Columns[5].Visible = false;
                    dgvNarudzbe.Columns[7].Visible = false;
                }
                else if (!chbIsIsporucena.Checked && chbIsPlacena.Checked)
                {
                    var request = new NarudzbaSearchObject()
                    {
                        IsPlacena = true
                    };
                    dgvNarudzbe.DataSource = null;
                    dgvNarudzbe.DataSource = await _narudzbaService.Get<IList<Modal.Narudzba>>(request);
                    dgvNarudzbe.Columns[1].Visible = false;
                    dgvNarudzbe.Columns[6].Visible = false;
                    dgvNarudzbe.Columns[5].Visible = false;
                    dgvNarudzbe.Columns[7].Visible = false;
                }
                else
                {
                    dgvNarudzbe.DataSource = null;
                    dgvNarudzbe.DataSource = await _narudzbaService.Get<IList<Modal.Narudzba>>(null);
                    dgvNarudzbe.Columns[1].Visible = false;
                    dgvNarudzbe.Columns[6].Visible = false;
                    dgvNarudzbe.Columns[5].Visible = false;
                    dgvNarudzbe.Columns[7].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void chbIsPlacena_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chbIsIsporucena.Checked && chbIsPlacena.Checked)
                {
                    var request = new NarudzbaSearchObject()
                    {
                        IsIsporucena = true,
                        IsPlacena = true
                    };
                    dgvNarudzbe.DataSource = null;
                    dgvNarudzbe.DataSource = await _narudzbaService.Get<IList<Modal.Narudzba>>(request);
                    dgvNarudzbe.Columns[1].Visible = false;
                    dgvNarudzbe.Columns[6].Visible = false;
                    dgvNarudzbe.Columns[5].Visible = false;
                    dgvNarudzbe.Columns[7].Visible = false;
                }
                else if (chbIsIsporucena.Checked && !chbIsPlacena.Checked)
                {
                    var request = new NarudzbaSearchObject()
                    {
                        IsIsporucena = true
                    };
                    dgvNarudzbe.DataSource = null;
                    dgvNarudzbe.DataSource = await _narudzbaService.Get<IList<Modal.Narudzba>>(request);
                    dgvNarudzbe.Columns[1].Visible = false;
                    dgvNarudzbe.Columns[6].Visible = false;
                    dgvNarudzbe.Columns[5].Visible = false;
                    dgvNarudzbe.Columns[7].Visible = false;
                }
                else if (!chbIsIsporucena.Checked && chbIsPlacena.Checked)
                {
                    var request = new NarudzbaSearchObject()
                    {
                        IsPlacena = true
                    };
                    dgvNarudzbe.DataSource = null;
                    dgvNarudzbe.DataSource = await _narudzbaService.Get<IList<Modal.Narudzba>>(request);
                    dgvNarudzbe.Columns[1].Visible = false;
                    dgvNarudzbe.Columns[6].Visible = false;
                    dgvNarudzbe.Columns[5].Visible = false;
                    dgvNarudzbe.Columns[7].Visible = false;
                }
                else
                {
                    dgvNarudzbe.DataSource = null;
                    dgvNarudzbe.DataSource = await _narudzbaService.Get<IList<Modal.Narudzba>>(null);
                    dgvNarudzbe.Columns[1].Visible = false;
                    dgvNarudzbe.Columns[6].Visible = false;
                    dgvNarudzbe.Columns[5].Visible = false;
                    dgvNarudzbe.Columns[7].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
