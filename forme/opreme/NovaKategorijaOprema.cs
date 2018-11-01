using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PonudaApp
{
    public partial class NovaKategorijaOprema : Form
    {
        public NovaKategorijaOprema()
        {
            InitializeComponent();
        }

        private void DodajKategorijuGumb_Click(object sender, EventArgs e)
        {
            Napredak.pokreniAkciju((Button)sender);
            
            if (Owner is NovaOprema)
            {
                ComboBox tempKategorijaOpremeComboBox = ((NovaOprema)Owner).getKategorijaOpremeComboBox();

                tempKategorijaOpremeComboBox.Items.Add(NovaKategorijaTextBox.Text);

                tempKategorijaOpremeComboBox.SelectedIndex = tempKategorijaOpremeComboBox.Items.Count - 1;
            }
            
            if (Owner is UrediOpremu)
            {
                ComboBox tempKategorijaOpremeComboBox = ((UrediOpremu)Owner).getKategorijaOpremeComboBox();

                tempKategorijaOpremeComboBox.Items.Add(NovaKategorijaTextBox.Text);

                tempKategorijaOpremeComboBox.SelectedIndex = tempKategorijaOpremeComboBox.Items.Count - 1;

            }

            Napredak.zavrsiAkciju((Button)sender);

            this.Close();
        }
    }
}
