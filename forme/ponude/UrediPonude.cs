using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;

namespace PonudaApp
{
    public partial class UrediPonude : Form
    {
        public UrediPonude()
        {
            InitializeComponent();
        }

        internal ListBox getPopisPonuda()
        {
            return PopisPonuda;
        }

        private void UrediPonude_Load(object sender, EventArgs e)
        {
            //PonudaDat.serijalizirajListuPonuda(new List<Ponuda>());

            List<Ponuda> listaPonuda = PonudaDat.deSerijalizirajListuPonuda();

            PopisPonuda.Items.AddRange(listaPonuda.ToArray());
        }

        private void UrediPonuduGumb_Click(object sender, EventArgs e)
        {
            if (PopisPonuda.SelectedItem != null)
            {
                Napredak.pokreniAkciju((Button)sender);
                
                UrediPonudu urediPonudu = new UrediPonudu();

                urediPonudu.Owner = this;

                urediPonudu.ShowDialog();

                Napredak.zavrsiAkciju((Button)sender);
            }
            else
            {
                MessageBox.Show("Prvo se treba selektirati ponuda.", "Alert", MessageBoxButtons.OK);
            }
        }

        private void RacunPonudeGumb_Click(object sender, EventArgs e)
        {
            if (PopisPonuda.SelectedItem != null)
            {
                Napredak.pokreniAkciju((Button)sender);

                IzvozHtml.izvozHtmlPonuda((Ponuda)PopisPonuda.SelectedItem);

                Napredak.zavrsiAkciju((Button)sender);
            }
            else
            {
                MessageBox.Show("Prvo se treba selektirati ponuda.", "Alert", MessageBoxButtons.OK);
            }
        }

        private void ObrisiPonuduGumb_Click(object sender, EventArgs e)
        {
            if (PopisPonuda.SelectedItem != null)
            {
                Napredak.pokreniAkciju((Button)sender);
                
                List<Ponuda> listaPonuda = PonudaDat.deSerijalizirajListuPonuda();

                listaPonuda.RemoveAt(PopisPonuda.SelectedIndex);

                PopisPonuda.Items.Clear();

                for (int i = 0; i < listaPonuda.Count; i++)
                {
                    Ponuda tempPonuda = listaPonuda[i];

                    tempPonuda.indexPonude = i;

                    PopisPonuda.Items.Add(tempPonuda);
                }

                PonudaDat.serijalizirajListuPonuda(listaPonuda);

                Napredak.zavrsiAkciju((Button)sender);
            }
            else
            {
                MessageBox.Show("Prvo se treba selektirati ponuda.", "Alert", MessageBoxButtons.OK);
            }
        }
    }
}
