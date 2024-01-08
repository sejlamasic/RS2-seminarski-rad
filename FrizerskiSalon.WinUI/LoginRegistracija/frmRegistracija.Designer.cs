
namespace FrizerskiSalon.WinUI.LoginRegistracija
{
    partial class frmRegistracija
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
            txtIme = new TextBox();
            txtKorisnickoIme = new TextBox();
            txtPrezime = new TextBox();
            txtPutanjaDoSlike = new TextBox();
            txtPotvrdaLozinke = new TextBox();
            txtLozinka = new TextBox();
            cmbSpol = new ComboBox();
            cmbZanimanje = new ComboBox();
            btnRegistracija = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            btnUcitajSliku = new Button();
            label9 = new Label();
            label10 = new Label();
            txtTelefon = new TextBox();
            txtEmail = new TextBox();
            err = new ErrorProvider(components);
            ofdSlika = new OpenFileDialog();
            panel1 = new Panel();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)err).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // txtIme
            // 
            txtIme.Location = new Point(189, 28);
            txtIme.Margin = new Padding(4, 5, 4, 5);
            txtIme.Name = "txtIme";
            txtIme.Size = new Size(294, 31);
            txtIme.TabIndex = 0;
            // 
            // txtKorisnickoIme
            // 
            txtKorisnickoIme.Location = new Point(189, 166);
            txtKorisnickoIme.Margin = new Padding(4, 5, 4, 5);
            txtKorisnickoIme.Name = "txtKorisnickoIme";
            txtKorisnickoIme.Size = new Size(294, 31);
            txtKorisnickoIme.TabIndex = 1;
            // 
            // txtPrezime
            // 
            txtPrezime.Location = new Point(189, 94);
            txtPrezime.Margin = new Padding(4, 5, 4, 5);
            txtPrezime.Name = "txtPrezime";
            txtPrezime.Size = new Size(294, 31);
            txtPrezime.TabIndex = 2;
            // 
            // txtPutanjaDoSlike
            // 
            txtPutanjaDoSlike.Location = new Point(691, 306);
            txtPutanjaDoSlike.Margin = new Padding(4, 5, 4, 5);
            txtPutanjaDoSlike.Name = "txtPutanjaDoSlike";
            txtPutanjaDoSlike.Size = new Size(219, 31);
            txtPutanjaDoSlike.TabIndex = 3;
            // 
            // txtPotvrdaLozinke
            // 
            txtPotvrdaLozinke.Location = new Point(189, 306);
            txtPotvrdaLozinke.Margin = new Padding(4, 5, 4, 5);
            txtPotvrdaLozinke.Name = "txtPotvrdaLozinke";
            txtPotvrdaLozinke.PasswordChar = '*';
            txtPotvrdaLozinke.Size = new Size(294, 31);
            txtPotvrdaLozinke.TabIndex = 4;
            // 
            // txtLozinka
            // 
            txtLozinka.Location = new Point(189, 238);
            txtLozinka.Margin = new Padding(4, 5, 4, 5);
            txtLozinka.Name = "txtLozinka";
            txtLozinka.PasswordChar = '*';
            txtLozinka.Size = new Size(294, 31);
            txtLozinka.TabIndex = 5;
            // 
            // cmbSpol
            // 
            cmbSpol.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSpol.FormattingEnabled = true;
            cmbSpol.Location = new Point(691, 158);
            cmbSpol.Margin = new Padding(4, 5, 4, 5);
            cmbSpol.Name = "cmbSpol";
            cmbSpol.Size = new Size(294, 33);
            cmbSpol.TabIndex = 6;
            // 
            // cmbZanimanje
            // 
            cmbZanimanje.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbZanimanje.FormattingEnabled = true;
            cmbZanimanje.Location = new Point(691, 230);
            cmbZanimanje.Margin = new Padding(4, 5, 4, 5);
            cmbZanimanje.Name = "cmbZanimanje";
            cmbZanimanje.Size = new Size(294, 33);
            cmbZanimanje.TabIndex = 7;
            // 
            // btnRegistracija
            // 
            btnRegistracija.Location = new Point(488, 397);
            btnRegistracija.Margin = new Padding(4, 5, 4, 5);
            btnRegistracija.Name = "btnRegistracija";
            btnRegistracija.Size = new Size(456, 53);
            btnRegistracija.TabIndex = 8;
            btnRegistracija.Text = "Registruj se";
            btnRegistracija.UseVisualStyleBackColor = true;
            btnRegistracija.Click += btnRegistracija_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(28, 28);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(42, 25);
            label1.TabIndex = 9;
            label1.Text = "Ime";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(28, 98);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(74, 25);
            label2.TabIndex = 10;
            label2.Text = "Prezime";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(28, 173);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(127, 25);
            label3.TabIndex = 11;
            label3.Text = "Korisničko ime";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(28, 245);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(71, 25);
            label4.TabIndex = 12;
            label4.Text = "Lozinka";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(28, 314);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(144, 25);
            label5.TabIndex = 13;
            label5.Text = "Potvrdite lozinku";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(530, 314);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(98, 25);
            label6.TabIndex = 14;
            label6.Text = "Fotografija";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(530, 169);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(48, 25);
            label7.TabIndex = 15;
            label7.Text = "Spol";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(530, 241);
            label8.Margin = new Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new Size(93, 25);
            label8.TabIndex = 16;
            label8.Text = "Zanimanje";
            // 
            // btnUcitajSliku
            // 
            btnUcitajSliku.Location = new Point(919, 309);
            btnUcitajSliku.Margin = new Padding(4, 5, 4, 5);
            btnUcitajSliku.Name = "btnUcitajSliku";
            btnUcitajSliku.Size = new Size(68, 36);
            btnUcitajSliku.TabIndex = 17;
            btnUcitajSliku.Text = "...";
            btnUcitajSliku.UseVisualStyleBackColor = true;
            btnUcitajSliku.Click += btnUcitajSliku_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(530, 98);
            label9.Margin = new Padding(4, 0, 4, 0);
            label9.Name = "label9";
            label9.Size = new Size(68, 25);
            label9.TabIndex = 21;
            label9.Text = "Telefon";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(530, 28);
            label10.Margin = new Padding(4, 0, 4, 0);
            label10.Name = "label10";
            label10.Size = new Size(54, 25);
            label10.TabIndex = 20;
            label10.Text = "Email";
            // 
            // txtTelefon
            // 
            txtTelefon.Location = new Point(691, 94);
            txtTelefon.Margin = new Padding(4, 5, 4, 5);
            txtTelefon.Name = "txtTelefon";
            txtTelefon.Size = new Size(294, 31);
            txtTelefon.TabIndex = 19;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(691, 28);
            txtEmail.Margin = new Padding(4, 5, 4, 5);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(294, 31);
            txtEmail.TabIndex = 18;
            // 
            // err
            // 
            err.ContainerControl = this;
            // 
            // ofdSlika
            // 
            ofdSlika.FileName = "openFileDialog1";
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.None;
            panel1.Controls.Add(button1);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(label9);
            panel1.Controls.Add(txtIme);
            panel1.Controls.Add(label10);
            panel1.Controls.Add(txtKorisnickoIme);
            panel1.Controls.Add(txtTelefon);
            panel1.Controls.Add(txtPrezime);
            panel1.Controls.Add(txtEmail);
            panel1.Controls.Add(txtPutanjaDoSlike);
            panel1.Controls.Add(btnUcitajSliku);
            panel1.Controls.Add(txtPotvrdaLozinke);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(txtLozinka);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(cmbSpol);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(cmbZanimanje);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(btnRegistracija);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label3);
            panel1.Location = new Point(15, 19);
            panel1.Margin = new Padding(4, 5, 4, 5);
            panel1.Name = "panel1";
            panel1.Size = new Size(1004, 467);
            panel1.TabIndex = 22;
            // 
            // button1
            // 
            button1.Location = new Point(24, 397);
            button1.Margin = new Padding(4, 5, 4, 5);
            button1.Name = "button1";
            button1.Size = new Size(275, 53);
            button1.TabIndex = 22;
            button1.Text = "Zatvori";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // frmRegistracija
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1036, 511);
            Controls.Add(panel1);
            Margin = new Padding(4, 5, 4, 5);
            Name = "frmRegistracija";
            Text = "frmRegistracija";
            Load += frmRegistracija_Load;
            ((System.ComponentModel.ISupportInitialize)err).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TextBox txtIme;
        private TextBox txtKorisnickoIme;
        private TextBox txtPrezime;
        private TextBox txtPutanjaDoSlike;
        private TextBox txtPotvrdaLozinke;
        private TextBox txtLozinka;
        private ComboBox cmbSpol;
        private ComboBox cmbZanimanje;
        private Button btnRegistracija;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Button btnUcitajSliku;
        private Label label9;
        private Label label10;
        private TextBox txtTelefon;
        private TextBox txtEmail;
        private ErrorProvider err;
        private OpenFileDialog ofdSlika;
        private Panel panel1;
        private Button button1;
    }
}