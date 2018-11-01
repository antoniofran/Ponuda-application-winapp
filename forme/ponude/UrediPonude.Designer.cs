namespace PonudaApp
{
    partial class UrediPonude
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UrediPonude));
            this.panel1 = new System.Windows.Forms.Panel();
            this.RacunPonudeGumb = new System.Windows.Forms.Button();
            this.UrediPonuduGumb = new System.Windows.Forms.Button();
            this.PopisPonuda = new System.Windows.Forms.ListBox();
            this.ObrisiPonuduGumb = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ObrisiPonuduGumb);
            this.panel1.Controls.Add(this.RacunPonudeGumb);
            this.panel1.Controls.Add(this.UrediPonuduGumb);
            this.panel1.Controls.Add(this.PopisPonuda);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(519, 241);
            this.panel1.TabIndex = 2;
            // 
            // RacunPonudeGumb
            // 
            this.RacunPonudeGumb.Location = new System.Drawing.Point(187, 208);
            this.RacunPonudeGumb.Name = "RacunPonudeGumb";
            this.RacunPonudeGumb.Size = new System.Drawing.Size(142, 23);
            this.RacunPonudeGumb.TabIndex = 2;
            this.RacunPonudeGumb.Text = "Račun selektirane ponude";
            this.RacunPonudeGumb.UseVisualStyleBackColor = true;
            this.RacunPonudeGumb.Click += new System.EventHandler(this.RacunPonudeGumb_Click);
            // 
            // UrediPonuduGumb
            // 
            this.UrediPonuduGumb.Location = new System.Drawing.Point(27, 208);
            this.UrediPonuduGumb.Name = "UrediPonuduGumb";
            this.UrediPonuduGumb.Size = new System.Drawing.Size(142, 23);
            this.UrediPonuduGumb.TabIndex = 1;
            this.UrediPonuduGumb.Text = "Uredi selektiranu ponudu";
            this.UrediPonuduGumb.UseVisualStyleBackColor = true;
            this.UrediPonuduGumb.Click += new System.EventHandler(this.UrediPonuduGumb_Click);
            // 
            // PopisPonuda
            // 
            this.PopisPonuda.FormattingEnabled = true;
            this.PopisPonuda.Location = new System.Drawing.Point(12, 12);
            this.PopisPonuda.Name = "PopisPonuda";
            this.PopisPonuda.Size = new System.Drawing.Size(495, 186);
            this.PopisPonuda.TabIndex = 0;
            // 
            // ObrisiPonuduGumb
            // 
            this.ObrisiPonuduGumb.Location = new System.Drawing.Point(346, 208);
            this.ObrisiPonuduGumb.Name = "ObrisiPonuduGumb";
            this.ObrisiPonuduGumb.Size = new System.Drawing.Size(142, 23);
            this.ObrisiPonuduGumb.TabIndex = 3;
            this.ObrisiPonuduGumb.Text = "Obrisi selektiranu ponudu";
            this.ObrisiPonuduGumb.UseVisualStyleBackColor = true;
            this.ObrisiPonuduGumb.Click += new System.EventHandler(this.ObrisiPonuduGumb_Click);
            // 
            // UrediPonude
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 241);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "UrediPonude";
            this.Text = "Arhiva ponuda";
            this.Load += new System.EventHandler(this.UrediPonude_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button RacunPonudeGumb;
        private System.Windows.Forms.Button UrediPonuduGumb;
        private System.Windows.Forms.ListBox PopisPonuda;
        private System.Windows.Forms.Button ObrisiPonuduGumb;
    }
}