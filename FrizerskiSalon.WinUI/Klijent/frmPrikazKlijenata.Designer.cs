
namespace FrizerskiSalon.WinUI.Klijent
{
    partial class frmPrikazKlijenata
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
            groupBox1 = new GroupBox();
            dgvKlijenti = new DataGridView();
            groupBox2 = new GroupBox();
            button1 = new Button();
            label2 = new Label();
            label1 = new Label();
            btnPrikazi = new Button();
            txtPrezime = new TextBox();
            txtIme = new TextBox();
            label3 = new Label();
            cmbSpol = new ComboBox();
            panel1 = new Panel();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvKlijenti).BeginInit();
            groupBox2.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(dgvKlijenti);
            groupBox1.Location = new Point(4, 159);
            groupBox1.Margin = new Padding(4, 5, 4, 5);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(4, 5, 4, 5);
            groupBox1.Size = new Size(1300, 811);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Klijenti";
            // 
            // dgvKlijenti
            // 
            dgvKlijenti.AllowUserToAddRows = false;
            dgvKlijenti.AllowUserToDeleteRows = false;
            dgvKlijenti.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvKlijenti.Dock = DockStyle.Fill;
            dgvKlijenti.Location = new Point(4, 29);
            dgvKlijenti.Margin = new Padding(4, 5, 4, 5);
            dgvKlijenti.Name = "dgvKlijenti";
            dgvKlijenti.ReadOnly = true;
            dgvKlijenti.RowHeadersWidth = 51;
            dgvKlijenti.RowTemplate.Height = 24;
            dgvKlijenti.Size = new Size(970, 477);
            dgvKlijenti.TabIndex = 0;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(button1);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(btnPrikazi);
            groupBox2.Controls.Add(txtPrezime);
            groupBox2.Controls.Add(txtIme);
            groupBox2.Location = new Point(4, 5);
            groupBox2.Margin = new Padding(4, 5, 4, 5);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(4, 5, 4, 5);
            groupBox2.Size = new Size(978, 145);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Pretraga";
            // 
            // button1
            // 
            button1.Location = new Point(731, 87);
            button1.Margin = new Padding(4, 5, 4, 5);
            button1.Name = "button1";
            button1.Size = new Size(229, 48);
            button1.TabIndex = 6;
            button1.Text = "Očisti";
            button1.UseVisualStyleBackColor = true;
            button1.Click += btnOcisti_Click;
            // 
            // label2
            // 
            label2.AutoSize = false;
            label2.Location = new Point(29, 92);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(74, 25);
            label2.TabIndex = 5;
            label2.Text = "Prezime";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(65, 48);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(42, 25);
            label1.TabIndex = 4;
            label1.Text = "Ime";
            // 
            // btnPrikazi
            // 
            btnPrikazi.Location = new Point(485, 88);
            btnPrikazi.Margin = new Padding(4, 5, 4, 5);
            btnPrikazi.Name = "btnPrikazi";
            btnPrikazi.Size = new Size(229, 48);
            btnPrikazi.TabIndex = 3;
            btnPrikazi.Text = "Pretraži";
            btnPrikazi.UseVisualStyleBackColor = true;
            btnPrikazi.Click += btnPrikazi_Click;
            // 
            // txtPrezime
            // 
            txtPrezime.Location = new Point(110, 88);
            txtPrezime.Margin = new Padding(4, 5, 4, 5);
            txtPrezime.Name = "txtPrezime";
            txtPrezime.Size = new Size(278, 31);
            txtPrezime.TabIndex = 2;
            // 
            // txtIme
            // 
            txtIme.Location = new Point(110, 44);
            txtIme.Margin = new Padding(4, 5, 4, 5);
            txtIme.Name = "txtIme";
            txtIme.Size = new Size(278, 31);
            txtIme.TabIndex = 0;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(362, 31);
            label3.Name = "label3";
            label3.Size = new Size(36, 17);
            label3.TabIndex = 6;
            label3.Text = "Spol";
            // 
            // cmbSpol
            // 
            cmbSpol.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSpol.FormattingEnabled = true;
            cmbSpol.Location = new Point(404, 29);
            cmbSpol.Name = "cmbSpol";
            cmbSpol.Size = new Size(183, 33);
            cmbSpol.TabIndex = 1;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.None;
            panel1.Controls.Add(groupBox2);
            panel1.Controls.Add(groupBox1);
            panel1.Location = new Point(15, 19);
            panel1.Margin = new Padding(4, 5, 4, 5);
            panel1.Name = "panel1";
            panel1.Size = new Size(994, 680);
            panel1.TabIndex = 1;
            // 
            // frmPrikazKlijenata
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1022, 720);
            Controls.Add(panel1);
            Margin = new Padding(4, 5, 4, 5);
            Name = "frmPrikazKlijenata";
            Text = "frmPrikazKlijenata";
            Load += frmPrikazKlijenata_Load;
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvKlijenti).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private DataGridView dgvKlijenti;
        private GroupBox groupBox2;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button btnPrikazi;
        private TextBox txtPrezime;
        private ComboBox cmbSpol;
        private TextBox txtIme;
        private Panel panel1;
        private Button button1;
    }
}