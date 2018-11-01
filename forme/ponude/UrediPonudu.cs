using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace PonudaApp
{
    public partial class UrediPonudu : Form
    {
        public UrediPonudu()
        {
            InitializeComponent();
        }

        internal ListBox getPopisDodatneOpremeListBox()
        {
            return PopisDodatneOpreme;
        }

        internal ComboBox getKabinaComboBox()
        {
            return KabinaComboBox;
        }

        internal ComboBox getTraktoriComboBox()
        {
            return TraktoriComboBox;
        }

        private void UrediPonudu_Load(object sender, EventArgs e)
        {
            OleDbConnection MyConn = BazaPodataka.openConnectionToDatabase();

            /* *********************** */

            OleDbCommand komanda = new OleDbCommand("SELECT * FROM Traktori", MyConn);

            OleDbDataReader dataSet = komanda.ExecuteReader();

            while (dataSet.Read())
            {
                Traktor tempTraktor = new Traktor();

                tempTraktor.idTraktora = Convert.ToInt32(dataSet["ID"].ToString());

                tempTraktor.nazivTraktora = dataSet["NazivTraktora"].ToString();

                string[] listStandardnaOpremaId = dataSet["StandardnaOpremaId"].ToString().Split("+".ToCharArray());

                foreach (string idOpreme in listStandardnaOpremaId)
                {
                    Oprema potencijalnaOprema = BazaPodataka.dohvatiOpremu(Convert.ToInt32(idOpreme));

                    if (potencijalnaOprema != null)
                    {
                        tempTraktor.standardnaOprema.Add(potencijalnaOprema);
                    }
                }

                Kabina potencijalnaKabina = BazaPodataka.dohvatiKabinu(Convert.ToInt32(dataSet["IdKabine"].ToString()));

                if (potencijalnaKabina != null)
                {
                    tempTraktor.kabinaTraktora = potencijalnaKabina;
                }
                else
                {
                    tempTraktor.kabinaTraktora = new Kabina();
                }

                tempTraktor.ulaznaCijena = Convert.ToDecimal(dataSet["UlaznaCijena"].ToString());

                tempTraktor.opisTraktora = dataSet["OpisTraktora"].ToString();

                TraktoriComboBox.Items.Add(tempTraktor);
            }

            dataSet.Close();

            /* *********************** */

            OleDbCommand komanda2 = new OleDbCommand("SELECT * FROM Kabine", MyConn);

            OleDbDataReader dataSet2 = komanda2.ExecuteReader();

            while (dataSet2.Read())
            {
                Kabina tempKabina = new Kabina();

                tempKabina.idKabine = Convert.ToInt32(dataSet2["ID"].ToString());

                tempKabina.nazivKabine = dataSet2["NazivKabine"].ToString();

                tempKabina.cijenaKabine = Convert.ToDecimal(dataSet2["CijenaKabine"].ToString());

                tempKabina.opisKabine = dataSet2["OpisKabine"].ToString();

                KabinaComboBox.Items.Add(tempKabina);
            }

            dataSet2.Close();

            /* *********************** */
            
            BazaPodataka.closeConnectionToDatabase(MyConn);

            /* *********************** */

            Ponuda tempPonuda = (Ponuda) ((UrediPonude)Owner).getPopisPonuda().SelectedItem;
                
            for (int i = 0; i < TraktoriComboBox.Items.Count; i++)
            {
                if ( ((Traktor)TraktoriComboBox.Items[i]).idTraktora == tempPonuda.traktorPonude.idTraktora )
                {
                    TraktoriComboBox.SelectedIndex = i;
                }
            }

            foreach (Oprema oprema in tempPonuda.dodatnaOprema)
            {
                Oprema potencijalnaOprema = BazaPodataka.dohvatiOpremu(oprema.idOpreme);

                if ( potencijalnaOprema != null )
                {
                    PopisDodatneOpreme.Items.Add(potencijalnaOprema);
                }
            }

            for (int i = 0; i < KabinaComboBox.Items.Count; i++)
            {
                if ( ((Kabina)KabinaComboBox.Items[i]).idKabine == tempPonuda.kabinaPonude.idKabine )
                {
                    KabinaComboBox.SelectedIndex = i;
                }
            }

            PopustNaIznosTextBox.Text = tempPonuda.popustNaIznosPostotak.ToString();

            NapomenaPonudeTextBox.Text = tempPonuda.napomenaPonude;

        }

        private void NoviTraktorGumb_Click(object sender, EventArgs e)
        {
            Napredak.pokreniAkciju((Button)sender);
            
            NoviTraktor noviTraktor = new NoviTraktor();

            noviTraktor.Owner = this;

            noviTraktor.ShowDialog();

            Napredak.zavrsiAkciju((Button)sender);
        }

        private void DodajDodatnuOpremuGumb_Click(object sender, EventArgs e)
        {
            if (TraktoriComboBox.SelectedIndex > -1)
            {
                Napredak.pokreniAkciju((Button)sender);

                OdaberiOpremuPonuda odaberiOpremuPonuda = new OdaberiOpremuPonuda();

                odaberiOpremuPonuda.Owner = this;

                odaberiOpremuPonuda.ShowDialog();

                Napredak.zavrsiAkciju((Button)sender);
            }
            else
            {
                MessageBox.Show("Prvo se treba izabrati traktor.", "Alert", MessageBoxButtons.OK);
            }

        }

        private void UkloniDodatnuOpremuGumb_Click(object sender, EventArgs e)
        {
            if (PopisDodatneOpreme.SelectedItem != null)
            {
                Napredak.pokreniAkciju((Button)sender);

                PopisDodatneOpreme.Items.Remove(PopisDodatneOpreme.SelectedItem);

                Napredak.zavrsiAkciju((Button)sender);
            }
            else
            {
                MessageBox.Show("Prvo se treba selektirati oprema.", "Alert", MessageBoxButtons.OK);
            }
        }

        private void NovaKabinaGumb_Click(object sender, EventArgs e)
        {
            Napredak.pokreniAkciju((Button)sender);

            NovaKabina novaKabina = new NovaKabina();

            novaKabina.Owner = this;

            novaKabina.ShowDialog();

            Napredak.zavrsiAkciju((Button)sender);
        }

        private void ObradiPonuduGumb_Click(object sender, EventArgs e)
        {
            if (TraktoriComboBox.SelectedItem == null || PopisDodatneOpreme.Items.Count == 0 || KabinaComboBox.SelectedItem == null || PopustNaIznosTextBox.Text == string.Empty || NapomenaPonudeTextBox.Text == string.Empty)
            {
                MessageBox.Show("Sva polja moraju biti popunjena.", "Alert", MessageBoxButtons.OK);
                return;
            }

            decimal tempPopustNaIznosPostotak = 0;

            PopustNaIznosTextBox.Text = PopustNaIznosTextBox.Text.Replace(".", ",");

            if (!decimal.TryParse(PopustNaIznosTextBox.Text, out tempPopustNaIznosPostotak))
            {
                MessageBox.Show("Popust na iznos mora biti broj.", "Alert", MessageBoxButtons.OK);
                return;
            }

            if (tempPopustNaIznosPostotak < 0 || tempPopustNaIznosPostotak > 100)
            {
                MessageBox.Show("Popust na iznos mora biti između 0 i 100.", "Alert", MessageBoxButtons.OK);
                return;
            }

            /* *********************** */

            Napredak.pokreniAkciju((Button)sender);

            /* *********************** */

            int tempIndexPonude = ((Ponuda)((UrediPonude)Owner).getPopisPonuda().SelectedItem).indexPonude;

            List<Oprema> tempListaDodatneOpreme = new List<Oprema>();

            foreach (Oprema oprema in PopisDodatneOpreme.Items)
            {
                tempListaDodatneOpreme.Add(oprema);
            }

            /* *********************** */

            Ponuda tempPonuda = new Ponuda(
                tempIndexPonude,
                (Traktor)TraktoriComboBox.SelectedItem,
                tempListaDodatneOpreme,
                (Kabina)KabinaComboBox.SelectedItem,
                tempPopustNaIznosPostotak,
                DateTime.Now,
                NapomenaPonudeTextBox.Text
            );

            /* *********************** */

            if (((Button)sender).Name == "IzvozHtmlGumb")
            {
                IzvozHtml.izvozHtmlPonuda(tempPonuda);
            }
            else
            {
                List<Ponuda> tempListaPonuda = PonudaDat.deSerijalizirajListuPonuda();

                /* *********************** */

                tempListaPonuda[tempIndexPonude] = tempPonuda;

                /* *********************** */

                int uredjivaniIndex = ((UrediPonude)Owner).getPopisPonuda().SelectedIndex;

                ((UrediPonude)Owner).getPopisPonuda().Items[uredjivaniIndex] = tempPonuda;

                /* ********************* */

                PonudaDat.serijalizirajListuPonuda(tempListaPonuda);

                /* ********************* */

                this.Close();
            }

            /* *********************** */

            Napredak.zavrsiAkciju((Button)sender);
        }

    }
}
