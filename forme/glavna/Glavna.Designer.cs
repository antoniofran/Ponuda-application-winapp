namespace PonudaApp
{
    partial class Glavna
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Glavna));
            this.NovaPonudaGumb = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.UrediPonudeGumb = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.UrediOpremeGumb = new System.Windows.Forms.Button();
            this.NovaOpremaGumb = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.UrediTraktoreGumb = new System.Windows.Forms.Button();
            this.NoviTraktorGumb = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.UrediKabineGumb = new System.Windows.Forms.Button();
            this.NovaKabinaGumb = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // NovaPonudaGumb
            // 
            this.NovaPonudaGumb.Location = new System.Drawing.Point(38, 37);
            this.NovaPonudaGumb.Name = "NovaPonudaGumb";
            this.NovaPonudaGumb.Size = new System.Drawing.Size(101, 23);
            this.NovaPonudaGumb.TabIndex = 0;
            this.NovaPonudaGumb.Text = "Nova ponuda";
            this.NovaPonudaGumb.UseVisualStyleBackColor = true;
            this.NovaPonudaGumb.Click += new System.EventHandler(this.NovaPonudaGumb_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.UrediPonudeGumb);
            this.groupBox1.Controls.Add(this.NovaPonudaGumb);
            this.groupBox1.Location = new System.Drawing.Point(202, 176);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(172, 146);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ponuda";
            // 
            // UrediPonudeGumb
            // 
            this.UrediPonudeGumb.Location = new System.Drawing.Point(38, 91);
            this.UrediPonudeGumb.Name = "UrediPonudeGumb";
            this.UrediPonudeGumb.Size = new System.Drawing.Size(101, 23);
            this.UrediPonudeGumb.TabIndex = 1;
            this.UrediPonudeGumb.Text = "Arhiva ponuda";
            this.UrediPonudeGumb.UseVisualStyleBackColor = true;
            this.UrediPonudeGumb.Click += new System.EventHandler(this.UrediPonudeGumb_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.UrediOpremeGumb);
            this.groupBox2.Controls.Add(this.NovaOpremaGumb);
            this.groupBox2.Location = new System.Drawing.Point(12, 9);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(177, 146);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Oprema";
            // 
            // UrediOpremeGumb
            // 
            this.UrediOpremeGumb.Location = new System.Drawing.Point(39, 91);
            this.UrediOpremeGumb.Name = "UrediOpremeGumb";
            this.UrediOpremeGumb.Size = new System.Drawing.Size(99, 23);
            this.UrediOpremeGumb.TabIndex = 1;
            this.UrediOpremeGumb.Text = "Uredi opreme";
            this.UrediOpremeGumb.UseVisualStyleBackColor = true;
            this.UrediOpremeGumb.Click += new System.EventHandler(this.UrediOpremeGumb_Click);
            // 
            // NovaOpremaGumb
            // 
            this.NovaOpremaGumb.Location = new System.Drawing.Point(39, 36);
            this.NovaOpremaGumb.Name = "NovaOpremaGumb";
            this.NovaOpremaGumb.Size = new System.Drawing.Size(99, 23);
            this.NovaOpremaGumb.TabIndex = 0;
            this.NovaOpremaGumb.Text = "Nova oprema";
            this.NovaOpremaGumb.UseVisualStyleBackColor = true;
            this.NovaOpremaGumb.Click += new System.EventHandler(this.NovaOpremaGumb_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.UrediTraktoreGumb);
            this.groupBox3.Controls.Add(this.NoviTraktorGumb);
            this.groupBox3.Location = new System.Drawing.Point(202, 9);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(172, 146);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Traktori";
            // 
            // UrediTraktoreGumb
            // 
            this.UrediTraktoreGumb.Location = new System.Drawing.Point(36, 91);
            this.UrediTraktoreGumb.Name = "UrediTraktoreGumb";
            this.UrediTraktoreGumb.Size = new System.Drawing.Size(99, 23);
            this.UrediTraktoreGumb.TabIndex = 1;
            this.UrediTraktoreGumb.Text = "Uredi traktore";
            this.UrediTraktoreGumb.UseVisualStyleBackColor = true;
            this.UrediTraktoreGumb.Click += new System.EventHandler(this.UrediTraktoreGumb_Click);
            // 
            // NoviTraktorGumb
            // 
            this.NoviTraktorGumb.Location = new System.Drawing.Point(36, 37);
            this.NoviTraktorGumb.Name = "NoviTraktorGumb";
            this.NoviTraktorGumb.Size = new System.Drawing.Size(99, 23);
            this.NoviTraktorGumb.TabIndex = 0;
            this.NoviTraktorGumb.Text = "Novi traktor";
            this.NoviTraktorGumb.UseVisualStyleBackColor = true;
            this.NoviTraktorGumb.Click += new System.EventHandler(this.NoviTraktorGumb_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.UrediKabineGumb);
            this.groupBox4.Controls.Add(this.NovaKabinaGumb);
            this.groupBox4.Location = new System.Drawing.Point(12, 176);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(177, 146);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Kabine";
            // 
            // UrediKabineGumb
            // 
            this.UrediKabineGumb.Location = new System.Drawing.Point(39, 91);
            this.UrediKabineGumb.Name = "UrediKabineGumb";
            this.UrediKabineGumb.Size = new System.Drawing.Size(99, 23);
            this.UrediKabineGumb.TabIndex = 1;
            this.UrediKabineGumb.Text = "Uredi kabine";
            this.UrediKabineGumb.UseVisualStyleBackColor = true;
            this.UrediKabineGumb.Click += new System.EventHandler(this.UrediKabineGumb_Click);
            // 
            // NovaKabinaGumb
            // 
            this.NovaKabinaGumb.Location = new System.Drawing.Point(39, 37);
            this.NovaKabinaGumb.Name = "NovaKabinaGumb";
            this.NovaKabinaGumb.Size = new System.Drawing.Size(99, 23);
            this.NovaKabinaGumb.TabIndex = 0;
            this.NovaKabinaGumb.Text = "Nova kabina";
            this.NovaKabinaGumb.UseVisualStyleBackColor = true;
            this.NovaKabinaGumb.Click += new System.EventHandler(this.NovaKabinaGumb_Click);
            // 
            // Glavna
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 333);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Glavna";
            this.Text = "PonudaApp";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button NovaPonudaGumb;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button UrediPonudeGumb;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button NovaOpremaGumb;
        private System.Windows.Forms.Button UrediOpremeGumb;
        private System.Windows.Forms.Button UrediTraktoreGumb;
        private System.Windows.Forms.Button NoviTraktorGumb;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button UrediKabineGumb;
        private System.Windows.Forms.Button NovaKabinaGumb;
    }
}

