namespace PonudaApp
{
    partial class UrediOpreme
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UrediOpreme));
            this.panel1 = new System.Windows.Forms.Panel();
            this.IzbrisiOpremuGumb = new System.Windows.Forms.Button();
            this.UrediOpremuGumb = new System.Windows.Forms.Button();
            this.PopisOprema = new System.Windows.Forms.ListBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.IzbrisiOpremuGumb);
            this.panel1.Controls.Add(this.UrediOpremuGumb);
            this.panel1.Controls.Add(this.PopisOprema);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(410, 243);
            this.panel1.TabIndex = 0;
            // 
            // IzbrisiOpremuGumb
            // 
            this.IzbrisiOpremuGumb.Location = new System.Drawing.Point(221, 208);
            this.IzbrisiOpremuGumb.Name = "IzbrisiOpremuGumb";
            this.IzbrisiOpremuGumb.Size = new System.Drawing.Size(145, 23);
            this.IzbrisiOpremuGumb.TabIndex = 2;
            this.IzbrisiOpremuGumb.Text = "Izbrisi selektiranu opremu";
            this.IzbrisiOpremuGumb.UseVisualStyleBackColor = true;
            this.IzbrisiOpremuGumb.Click += new System.EventHandler(this.IzbrisiOpremuGumb_Click);
            // 
            // UrediOpremuGumb
            // 
            this.UrediOpremuGumb.Location = new System.Drawing.Point(48, 208);
            this.UrediOpremuGumb.Name = "UrediOpremuGumb";
            this.UrediOpremuGumb.Size = new System.Drawing.Size(145, 23);
            this.UrediOpremuGumb.TabIndex = 1;
            this.UrediOpremuGumb.Text = "Uredi selektiranu opremu";
            this.UrediOpremuGumb.UseVisualStyleBackColor = true;
            this.UrediOpremuGumb.Click += new System.EventHandler(this.UrediOpremuGumb_Click);
            // 
            // PopisOprema
            // 
            this.PopisOprema.FormattingEnabled = true;
            this.PopisOprema.Location = new System.Drawing.Point(12, 12);
            this.PopisOprema.Name = "PopisOprema";
            this.PopisOprema.Size = new System.Drawing.Size(386, 186);
            this.PopisOprema.TabIndex = 0;
            // 
            // UrediOpreme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 243);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "UrediOpreme";
            this.Text = "Uredi opreme ...";
            this.Load += new System.EventHandler(this.UrediOpreme_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button UrediOpremuGumb;
        private System.Windows.Forms.ListBox PopisOprema;
        private System.Windows.Forms.Button IzbrisiOpremuGumb;
    }
}