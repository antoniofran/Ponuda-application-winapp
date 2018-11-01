namespace PonudaApp
{
    partial class UrediKabine
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UrediKabine));
            this.panel1 = new System.Windows.Forms.Panel();
            this.IzbrisiKabinuGumb = new System.Windows.Forms.Button();
            this.UrediKabinuGumb = new System.Windows.Forms.Button();
            this.PopisKabina = new System.Windows.Forms.ListBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.IzbrisiKabinuGumb);
            this.panel1.Controls.Add(this.UrediKabinuGumb);
            this.panel1.Controls.Add(this.PopisKabina);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(410, 241);
            this.panel1.TabIndex = 1;
            // 
            // IzbrisiKabinuGumb
            // 
            this.IzbrisiKabinuGumb.Location = new System.Drawing.Point(219, 208);
            this.IzbrisiKabinuGumb.Name = "IzbrisiKabinuGumb";
            this.IzbrisiKabinuGumb.Size = new System.Drawing.Size(143, 23);
            this.IzbrisiKabinuGumb.TabIndex = 2;
            this.IzbrisiKabinuGumb.Text = "Izbrisi selektiranu kabinu";
            this.IzbrisiKabinuGumb.UseVisualStyleBackColor = true;
            this.IzbrisiKabinuGumb.Click += new System.EventHandler(this.IzbrisiKabinuGumb_Click);
            // 
            // UrediKabinuGumb
            // 
            this.UrediKabinuGumb.Location = new System.Drawing.Point(46, 208);
            this.UrediKabinuGumb.Name = "UrediKabinuGumb";
            this.UrediKabinuGumb.Size = new System.Drawing.Size(143, 23);
            this.UrediKabinuGumb.TabIndex = 1;
            this.UrediKabinuGumb.Text = "Uredi selektiranu kabinu";
            this.UrediKabinuGumb.UseVisualStyleBackColor = true;
            this.UrediKabinuGumb.Click += new System.EventHandler(this.UrediKabinuGumb_Click);
            // 
            // PopisKabina
            // 
            this.PopisKabina.FormattingEnabled = true;
            this.PopisKabina.Location = new System.Drawing.Point(12, 12);
            this.PopisKabina.Name = "PopisKabina";
            this.PopisKabina.Size = new System.Drawing.Size(386, 186);
            this.PopisKabina.TabIndex = 0;
            // 
            // UrediKabine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 241);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "UrediKabine";
            this.Text = "Uredi kabine ...";
            this.Load += new System.EventHandler(this.UrediKabine_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button IzbrisiKabinuGumb;
        private System.Windows.Forms.Button UrediKabinuGumb;
        private System.Windows.Forms.ListBox PopisKabina;
    }
}