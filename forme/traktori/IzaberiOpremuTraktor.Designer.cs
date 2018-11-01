namespace PonudaApp
{
    partial class IzaberiOpremuTraktor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IzaberiOpremuTraktor));
            this.panel1 = new System.Windows.Forms.Panel();
            this.DodajNovuOpremuGumb = new System.Windows.Forms.Button();
            this.IzaberiGumb = new System.Windows.Forms.Button();
            this.PopisStandardneOpreme = new System.Windows.Forms.ListBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.DodajNovuOpremuGumb);
            this.panel1.Controls.Add(this.IzaberiGumb);
            this.panel1.Controls.Add(this.PopisStandardneOpreme);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(497, 136);
            this.panel1.TabIndex = 1;
            // 
            // DodajNovuOpremuGumb
            // 
            this.DodajNovuOpremuGumb.Location = new System.Drawing.Point(263, 101);
            this.DodajNovuOpremuGumb.Name = "DodajNovuOpremuGumb";
            this.DodajNovuOpremuGumb.Size = new System.Drawing.Size(176, 23);
            this.DodajNovuOpremuGumb.TabIndex = 4;
            this.DodajNovuOpremuGumb.Text = "Kreiraj novu opremu";
            this.DodajNovuOpremuGumb.UseVisualStyleBackColor = true;
            this.DodajNovuOpremuGumb.Click += new System.EventHandler(this.DodajNovuOpremuGumb_Click);
            // 
            // IzaberiGumb
            // 
            this.IzaberiGumb.Location = new System.Drawing.Point(56, 101);
            this.IzaberiGumb.Name = "IzaberiGumb";
            this.IzaberiGumb.Size = new System.Drawing.Size(166, 23);
            this.IzaberiGumb.TabIndex = 3;
            this.IzaberiGumb.Text = "Dodaj selektiranu opremu";
            this.IzaberiGumb.UseVisualStyleBackColor = true;
            this.IzaberiGumb.Click += new System.EventHandler(this.IzaberiGumb_Click);
            // 
            // PopisStandardneOpreme
            // 
            this.PopisStandardneOpreme.FormattingEnabled = true;
            this.PopisStandardneOpreme.Location = new System.Drawing.Point(12, 12);
            this.PopisStandardneOpreme.Name = "PopisStandardneOpreme";
            this.PopisStandardneOpreme.Size = new System.Drawing.Size(473, 82);
            this.PopisStandardneOpreme.TabIndex = 2;
            // 
            // IzaberiOpremuTraktor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 136);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "IzaberiOpremuTraktor";
            this.Text = "Odabir standardne opreme traktora ...";
            this.Load += new System.EventHandler(this.IzaberiOpremuTraktor_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button IzaberiGumb;
        private System.Windows.Forms.ListBox PopisStandardneOpreme;
        private System.Windows.Forms.Button DodajNovuOpremuGumb;
    }
}