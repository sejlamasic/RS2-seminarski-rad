
namespace FrizerskiSalon.WinUI.Proizvod
{
    partial class frmProizvodDetalji
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            groupBox1 = new GroupBox();
            btnUcitajSliku = new Button();
            txtPutanjaDoSlike = new TextBox();
            label5 = new Label();
            btnObrisi = new Button();
            btnSpremi = new Button();
            cmbTipProizvoda = new ComboBox();
            txtOpis = new RichTextBox();
            txtCijena = new TextBox();
            txtNaziv = new TextBox();
            pcbSlika = new PictureBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            ofdSlika = new OpenFileDialog();
            err = new ErrorProvider(components);
            panel1 = new Panel();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pcbSlika).BeginInit();
            ((System.ComponentModel.ISupportInitialize)err).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnUcitajSliku);
            groupBox1.Controls.Add(txtPutanjaDoSlike);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(btnObrisi);
            groupBox1.Controls.Add(btnSpremi);
            groupBox1.Controls.Add(cmbTipProizvoda);
            groupBox1.Controls.Add(txtOpis);
            groupBox1.Controls.Add(txtCijena);
            groupBox1.Controls.Add(txtNaziv);
            groupBox1.Controls.Add(pcbSlika);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(4, 5);
            groupBox1.Margin = new Padding(4, 5, 4, 5);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(4, 5, 4, 5);
            groupBox1.Size = new Size(736, 592);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Detalji proizvoda";
            // 
            // btnUcitajSliku
            // 
            btnUcitajSliku.Location = new Point(665, 248);
            btnUcitajSliku.Margin = new Padding(4, 5, 4, 5);
            btnUcitajSliku.Name = "btnUcitajSliku";
            btnUcitajSliku.Size = new Size(64, 36);
            btnUcitajSliku.TabIndex = 13;
            btnUcitajSliku.Text = "...";
            btnUcitajSliku.UseVisualStyleBackColor = true;
            btnUcitajSliku.Click += btnUcitajSliku_Click;
            // 
            // txtPutanjaDoSlike
            // 
            txtPutanjaDoSlike.Location = new Point(174, 248);
            txtPutanjaDoSlike.Margin = new Padding(4, 5, 4, 5);
            txtPutanjaDoSlike.Name = "txtPutanjaDoSlike";
            txtPutanjaDoSlike.Size = new Size(483, 31);
            txtPutanjaDoSlike.TabIndex = 12;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(19, 248);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(136, 25);
            label5.TabIndex = 11;
            label5.Text = "Putanja do slike";
            // 
            // btnObrisi
            // 
            btnObrisi.Location = new Point(22, 512);
            btnObrisi.Margin = new Padding(4, 5, 4, 5);
            btnObrisi.Name = "btnObrisi";
            btnObrisi.Size = new Size(221, 48);
            btnObrisi.TabIndex = 10;
            btnObrisi.Text = "Obriši";
            btnObrisi.UseVisualStyleBackColor = true;
            btnObrisi.Click += btnObrisi_Click;
            // 
            // btnSpremi
            // 
            btnSpremi.Location = new Point(508, 512);
            btnSpremi.Margin = new Padding(4, 5, 4, 5);
            btnSpremi.Name = "btnSpremi";
            btnSpremi.Size = new Size(221, 48);
            btnSpremi.TabIndex = 9;
            btnSpremi.Text = "Sačuvaj";
            btnSpremi.UseVisualStyleBackColor = true;
            btnSpremi.Click += btnSpremi_Click;
            // 
            // cmbTipProizvoda
            // 
            cmbTipProizvoda.DisplayMember = "Naziv";
            cmbTipProizvoda.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipProizvoda.FormattingEnabled = true;
            cmbTipProizvoda.Location = new Point(174, 112);
            cmbTipProizvoda.Margin = new Padding(4, 5, 4, 5);
            cmbTipProizvoda.Name = "cmbTipProizvoda";
            cmbTipProizvoda.Size = new Size(350, 33);
            cmbTipProizvoda.TabIndex = 8;
            cmbTipProizvoda.ValueMember = "TipProizvodumId";
            // 
            // txtOpis
            // 
            txtOpis.Location = new Point(174, 311);
            txtOpis.Margin = new Padding(4, 5, 4, 5);
            txtOpis.MaxLength = 40;
            txtOpis.Name = "txtOpis";
            txtOpis.Size = new Size(554, 152);
            txtOpis.TabIndex = 7;
            txtOpis.Text = "";
            // 
            // txtCijena
            // 
            txtCijena.Location = new Point(174, 175);
            txtCijena.Margin = new Padding(4, 5, 4, 5);
            txtCijena.Name = "txtCijena";
            txtCijena.Size = new Size(350, 31);
            txtCijena.TabIndex = 6;
            // 
            // txtNaziv
            // 
            txtNaziv.Location = new Point(174, 50);
            txtNaziv.Margin = new Padding(4, 5, 4, 5);
            txtNaziv.MaxLength = 35;
            txtNaziv.Name = "txtNaziv";
            txtNaziv.Size = new Size(350, 31);
            txtNaziv.TabIndex = 5;
            // 
            // pcbSlika
            // 
            pcbSlika.Location = new Point(532, 19);
            pcbSlika.Margin = new Padding(4, 5, 4, 5);
            pcbSlika.Name = "pcbSlika";
            pcbSlika.Size = new Size(196, 212);
            pcbSlika.SizeMode = PictureBoxSizeMode.StretchImage;
            pcbSlika.TabIndex = 4;
            pcbSlika.TabStop = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(19, 320);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(49, 25);
            label4.TabIndex = 3;
            label4.Text = "Opis";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(19, 183);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(59, 25);
            label3.TabIndex = 2;
            label3.Text = "Cijena";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(19, 112);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(121, 25);
            label2.TabIndex = 1;
            label2.Text = "Tip proizvoda";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(19, 58);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(55, 25);
            label1.TabIndex = 0;
            label1.Text = "Naziv";
            // 
            // ofdSlika
            // 
            ofdSlika.FileName = "openFileDialog1";
            // 
            // err
            // 
            err.ContainerControl = this;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.None;
            panel1.Controls.Add(groupBox1);
            panel1.Location = new Point(168, 19);
            panel1.Margin = new Padding(4, 5, 4, 5);
            panel1.Name = "panel1";
            panel1.Size = new Size(754, 616);
            panel1.TabIndex = 14;
            // 
            // frmProizvodDetalji
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1089, 658);
            Controls.Add(panel1);
            Margin = new Padding(4, 5, 4, 5);
            Name = "frmProizvodDetalji";
            Text = "frmProizvodDetalji";
            Load += frmProizvodDetalji_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pcbSlika).EndInit();
            ((System.ComponentModel.ISupportInitialize)err).EndInit();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Button btnObrisi;
        private Button btnSpremi;
        private ComboBox cmbTipProizvoda;
        private RichTextBox txtOpis;
        private TextBox txtCijena;
        private TextBox txtNaziv;
        private PictureBox pcbSlika;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox txtPutanjaDoSlike;
        private Label label5;
        private Button btnUcitajSliku;
        private OpenFileDialog ofdSlika;
        private ErrorProvider err;
        private Panel panel1;
    }
}