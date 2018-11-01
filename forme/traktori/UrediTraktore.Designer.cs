namespace PonudaApp
{
    partial class UrediTraktore
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UrediTraktore));
            this.panel1 = new System.Windows.Forms.Panel();
            this.IzbrisiTraktorGumb = new System.Windows.Forms.Button();
            this.UrediTraktorGumb = new System.Windows.Forms.Button();
            this.PopisTraktora = new System.Windows.Forms.ListBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.IzbrisiTraktorGumb);
            this.panel1.Controls.Add(this.UrediTraktorGumb);
            this.panel1.Controls.Add(this.PopisTraktora);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(410, 244);
            this.panel1.TabIndex = 2;
            // 
            // IzbrisiTraktorGumb
            // 
            this.IzbrisiTraktorGumb.Location = new System.Drawing.Point(221, 209);
            this.IzbrisiTraktorGumb.Name = "IzbrisiTraktorGumb";
            this.IzbrisiTraktorGumb.Size = new System.Drawing.Size(137, 23);
            this.IzbrisiTraktorGumb.TabIndex = 2;
            this.IzbrisiTraktorGumb.Text = "Izbrisi selektirani traktor";
            this.IzbrisiTraktorGumb.UseVisualStyleBackColor = true;
            this.IzbrisiTraktorGumb.Click += new System.EventHandler(this.IzbrisiTraktorGumb_Click);
            // 
            // UrediTraktorGumb
            // 
            this.UrediTraktorGumb.Location = new System.Drawing.Point(48, 208);
            this.UrediTraktorGumb.Name = "UrediTraktorGumb";
            this.UrediTraktorGumb.Size = new System.Drawing.Size(137, 23);
            this.UrediTraktorGumb.TabIndex = 1;
            this.UrediTraktorGumb.Text = "Uredi selektirani traktor";
            this.UrediTraktorGumb.UseVisualStyleBackColor = true;
            this.UrediTraktorGumb.Click += new System.EventHandler(this.UrediTraktorGumb_Click);
            // 
            // PopisTraktora
            // 
            this.PopisTraktora.FormattingEnabled = true;
            this.PopisTraktora.Location = new System.Drawing.Point(12, 12);
            this.PopisTraktora.Name = "PopisTraktora";
            this.PopisTraktora.Size = new System.Drawing.Size(386, 186);
            this.PopisTraktora.TabIndex = 0;
            // 
            // UrediTraktore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 244);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "UrediTraktore";
            this.Text = "Uredi traktore ...";
            this.Load += new System.EventHandler(this.UrediTraktore_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button IzbrisiTraktorGumb;
        private System.Windows.Forms.Button UrediTraktorGumb;
        private System.Windows.Forms.ListBox PopisTraktora;
    }
}