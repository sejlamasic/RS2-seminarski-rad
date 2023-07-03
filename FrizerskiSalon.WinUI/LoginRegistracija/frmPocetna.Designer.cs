
namespace FrizerskiSalon.WinUI
{
    partial class frmPocetna
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
            menuStrip = new MenuStrip();
            izvještajiToolStripMenuItem = new ToolStripMenuItem();
            klijentiToolStripMenuItem = new ToolStripMenuItem();
            narudžbeToolStripMenuItem = new ToolStripMenuItem();
            obavijestiToolStripMenuItem = new ToolStripMenuItem();
            portfolioToolStripMenuItem = new ToolStripMenuItem();
            proizvodiToolStripMenuItem = new ToolStripMenuItem();
            terminiToolStripMenuItem = new ToolStripMenuItem();
            uposlenikProfilToolStripMenuItem = new ToolStripMenuItem();
            statusStrip = new StatusStrip();
            toolStripStatusLabel = new ToolStripStatusLabel();
            toolTip = new ToolTip(components);
            menuStrip.SuspendLayout();
            statusStrip.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip
            // 
            menuStrip.ImageScalingSize = new Size(20, 20);
            menuStrip.Items.AddRange(new ToolStripItem[] { izvještajiToolStripMenuItem, klijentiToolStripMenuItem, narudžbeToolStripMenuItem, obavijestiToolStripMenuItem, portfolioToolStripMenuItem, proizvodiToolStripMenuItem, terminiToolStripMenuItem, uposlenikProfilToolStripMenuItem });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Padding = new Padding(8, 3, 0, 3);
            menuStrip.Size = new Size(1054, 35);
            menuStrip.TabIndex = 0;
            menuStrip.Text = "MenuStrip";
            // 
            // izvještajiToolStripMenuItem
            // 
            izvještajiToolStripMenuItem.Name = "izvještajiToolStripMenuItem";
            izvještajiToolStripMenuItem.Size = new Size(94, 29);
            izvještajiToolStripMenuItem.Text = "Izvještaji";
            izvještajiToolStripMenuItem.Click += izvještajiToolStripMenuItem_Click;
            // 
            // klijentiToolStripMenuItem
            // 
            klijentiToolStripMenuItem.Name = "klijentiToolStripMenuItem";
            klijentiToolStripMenuItem.Size = new Size(79, 29);
            klijentiToolStripMenuItem.Text = "Klijenti";
            klijentiToolStripMenuItem.Click += klijentiToolStripMenuItem_Click;
            // 
            // narudžbeToolStripMenuItem
            // 
            narudžbeToolStripMenuItem.Name = "narudžbeToolStripMenuItem";
            narudžbeToolStripMenuItem.Size = new Size(105, 29);
            narudžbeToolStripMenuItem.Text = "Narudžbe";
            narudžbeToolStripMenuItem.Click += narudžbeToolStripMenuItem_Click;
            // 
            // obavijestiToolStripMenuItem
            // 
            obavijestiToolStripMenuItem.Name = "obavijestiToolStripMenuItem";
            obavijestiToolStripMenuItem.Size = new Size(106, 29);
            obavijestiToolStripMenuItem.Text = "Obavijesti";
            obavijestiToolStripMenuItem.Click += obavijestiToolStripMenuItem_Click;
            // 
            // portfolioToolStripMenuItem
            // 
            portfolioToolStripMenuItem.Name = "portfolioToolStripMenuItem";
            portfolioToolStripMenuItem.Size = new Size(96, 29);
            portfolioToolStripMenuItem.Text = "Portfolio";
            portfolioToolStripMenuItem.Click += portfolioToolStripMenuItem_Click;
            // 
            // proizvodiToolStripMenuItem
            // 
            proizvodiToolStripMenuItem.Name = "proizvodiToolStripMenuItem";
            proizvodiToolStripMenuItem.Size = new Size(102, 29);
            proizvodiToolStripMenuItem.Text = "Proizvodi";
            proizvodiToolStripMenuItem.Click += proizvodiToolStripMenuItem_Click;
            // 
            // terminiToolStripMenuItem
            // 
            terminiToolStripMenuItem.Name = "terminiToolStripMenuItem";
            terminiToolStripMenuItem.Size = new Size(84, 29);
            terminiToolStripMenuItem.Text = "Termini";
            terminiToolStripMenuItem.Click += terminiToolStripMenuItem_Click;
            // 
            // uposlenikProfilToolStripMenuItem
            // 
            uposlenikProfilToolStripMenuItem.Name = "uposlenikProfilToolStripMenuItem";
            uposlenikProfilToolStripMenuItem.Size = new Size(153, 29);
            uposlenikProfilToolStripMenuItem.Text = "Uposlenik profil";
            uposlenikProfilToolStripMenuItem.Click += uposlenikProfilToolStripMenuItem_Click;
            // 
            // statusStrip
            // 
            statusStrip.ImageScalingSize = new Size(20, 20);
            statusStrip.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel });
            statusStrip.Location = new Point(0, 840);
            statusStrip.Name = "statusStrip";
            statusStrip.Padding = new Padding(1, 0, 24, 0);
            statusStrip.Size = new Size(1054, 32);
            statusStrip.TabIndex = 2;
            statusStrip.Text = "StatusStrip";
            // 
            // toolStripStatusLabel
            // 
            toolStripStatusLabel.Name = "toolStripStatusLabel";
            toolStripStatusLabel.Size = new Size(60, 25);
            toolStripStatusLabel.Text = "Status";
            // 
            // frmPocetna
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1054, 872);
            Controls.Add(statusStrip);
            Controls.Add(menuStrip);
            IsMdiContainer = true;
            MainMenuStrip = menuStrip;
            Margin = new Padding(5, 6, 5, 6);
            Name = "frmPocetna";
            Text = "Frizerski salon";
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion


        private MenuStrip menuStrip;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel toolStripStatusLabel;
        private ToolTip toolTip;
        private ToolStripMenuItem izvještajiToolStripMenuItem;
        private ToolStripMenuItem klijentiToolStripMenuItem;
        private ToolStripMenuItem narudžbeToolStripMenuItem;
        private ToolStripMenuItem obavijestiToolStripMenuItem;
        private ToolStripMenuItem portfolioToolStripMenuItem;
        private ToolStripMenuItem proizvodiToolStripMenuItem;
        private ToolStripMenuItem terminiToolStripMenuItem;
        private ToolStripMenuItem uposlenikProfilToolStripMenuItem;
    }
}



