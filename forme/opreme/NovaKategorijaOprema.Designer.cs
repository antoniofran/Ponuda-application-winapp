namespace PonudaApp
{
    partial class NovaKategorijaOprema
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NovaKategorijaOprema));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.DodajKategorijuGumb = new System.Windows.Forms.Button();
            this.NovaKategorijaTextBox = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.DodajKategorijuGumb);
            this.panel1.Controls.Add(this.NovaKategorijaTextBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(242, 71);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "Naziv:";
            // 
            // DodajKategorijuGumb
            // 
            this.DodajKategorijuGumb.Location = new System.Drawing.Point(47, 38);
            this.DodajKategorijuGumb.Name = "DodajKategorijuGumb";
            this.DodajKategorijuGumb.Size = new System.Drawing.Size(147, 23);
            this.DodajKategorijuGumb.TabIndex = 1;
            this.DodajKategorijuGumb.Text = "Dodaj kategoriju opreme";
            this.DodajKategorijuGumb.UseVisualStyleBackColor = true;
            this.DodajKategorijuGumb.Click += new System.EventHandler(this.DodajKategorijuGumb_Click);
            // 
            // NovaKategorijaTextBox
            // 
            this.NovaKategorijaTextBox.Location = new System.Drawing.Point(62, 12);
            this.NovaKategorijaTextBox.Name = "NovaKategorijaTextBox";
            this.NovaKategorijaTextBox.Size = new System.Drawing.Size(169, 20);
            this.NovaKategorijaTextBox.TabIndex = 0;
            // 
            // NovaKategorijaOprema
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(242, 71);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "NovaKategorijaOprema";
            this.Text = "Nova kategorija opreme ...";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button DodajKategorijuGumb;
        private System.Windows.Forms.TextBox NovaKategorijaTextBox;
        private System.Windows.Forms.Label label1;
    }
}