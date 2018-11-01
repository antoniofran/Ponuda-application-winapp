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

namespace PonudaApp
{
    public partial class UrediTraktor : Form
    {
        public UrediTraktor()
        {
            InitializeComponent();
        }

        internal ListBox getStandardnaOpremaListBox()
        {
            return StandardnaOpremaListBox;
        }

        internal ComboBox getKabinaComboBox()
        {
            return KabinaComboBox;
        }

        private void UrediTraktor_Load(object sender, EventArgs e)
        {
            OleDbConnection MyConn = BazaPodataka.openConnectionToDatabase();

            /* ******************************** */

            OleDbCommand komanda = new OleDbCommand("SELECT * FROM Kabine", MyConn);

            OleDbDataReader dataSet = komanda.ExecuteReader();

            while (dataSet.Read())
            {
                Kabina tempKabina = new Kabina();

                tempKabina.idKabine = Convert.ToInt32(dataSet["ID"].ToString());

                tempKabina.nazivKabine = dataSet["NazivKabine"].ToString();

                tempKabina.cijenaKabine = Convert.ToDecimal(dataSet["CijenaKabine"].ToString());

                tempKabina.opisKabine = dataSet["OpisKabine"].ToString();

                KabinaComboBox.Items.Add(tempKabina);
            }

            dataSet.Close();

            /* ********************************* */

            OleDbCommand komanda2 = new OleDbCommand("SELECT * FROM Traktori WHERE [ID]=@ID;", MyConn);

            komanda2.Parameters.AddWithValue("@ID", ((Traktor)((UrediTraktore)Owner).getPopisTraktora().SelectedItem).idTraktora.ToString());

            OleDbDataReader dataSet2 = komanda2.ExecuteReader();

            while (dataSet2.Read())
            {
                NazivTraktoraTextBox.Text = dataSet2["NazivTraktora"].ToString();

                string[] listStandardnaOpremaId = dataSet2["StandardnaOpremaId"].ToString().Split("+".ToCharArray());

                foreach (string idOpreme in listStandardnaOpremaId)
                {
                    Oprema potencijalnaOprema = BazaPodataka.dohvatiOpremu(Convert.ToInt32(idOpreme));

                    if (potencijalnaOprema != null)
                    {
                        StandardnaOpremaListBox.Items.Add(potencijalnaOprema);
                    }                    
                }

                for (int i = 0; i < KabinaComboBox.Items.Count; i++)
                {
                    if ( ((Kabina)KabinaComboBox.Items[i]).idKabine == Convert.ToInt32(dataSet2["IdKabine"]) )
                    {
                        KabinaComboBox.SelectedIndex = i;
                    }
                }

                UlaznaCijenaTextBox.Text = dataSet2["UlaznaCijena"].ToString();

                OpisTraktoraTextBox.Text = dataSet2["OpisTraktora"].ToString();
            }

            dataSet2.Close();

            /* ********************************* */

            BazaPodataka.closeConnectionToDatabase(MyConn);
        }

        private void DodajOpremuGumb_Click(object sender, EventArgs e)
        {
            Napredak.pokreniAkciju((Button)sender);
            
            IzaberiOpremuTraktor izaberiOpremuTraktor = new IzaberiOpremuTraktor();

            izaberiOpremuTraktor.Owner = this;

            izaberiOpremuTraktor.ShowDialog();

            Napredak.zavrsiAkciju((Button)sender);
        }

        private void UkloniOpremu_Click(object sender, EventArgs e)
        {
            if (StandardnaOpremaListBox.SelectedItem != null)
            {
                Napredak.pokreniAkciju((Button)sender);

                StandardnaOpremaListBox.Items.Remove(StandardnaOpremaListBox.SelectedItem);

                Napredak.zavrsiAkciju((Button)sender);
            }
            else
            {
                MessageBox.Show("Prvo se treba selektirati oprema.", "Alert", MessageBoxButtons.OK);
            }
        }

        private void DodajKabinuGumb_Click(object sender, EventArgs e)
        {
            Napredak.pokreniAkciju((Button)sender);
            
            NovaKabina novaKabina = new NovaKabina();

            novaKabina.Owner = this;

            novaKabina.ShowDialog();

            Napredak.zavrsiAkciju((Button)sender);
        }

        private void SpremiTraktorGumb_Click(object sender, EventArgs e)
        {

            if (NazivTraktoraTextBox.Text == string.Empty || StandardnaOpremaListBox.Items.Count == 0 || KabinaComboBox.SelectedItem == null || UlaznaCijenaTextBox.Text == string.Empty || OpisTraktoraTextBox.Text == string.Empty)
            {
                MessageBox.Show("Sva polja moraju biti popunjena.", "Alert", MessageBoxButtons.OK);
                return;
            }

            decimal tempCijenaTraktora = 0;

            UlaznaCijenaTextBox.Text = UlaznaCijenaTextBox.Text.Replace(".", ",");

            if (!decimal.TryParse(UlaznaCijenaTextBox.Text, out tempCijenaTraktora))
            {
                MessageBox.Show("Cijena traktora mora biti broj.", "Alert", MessageBoxButtons.OK);
                return;
            }

            /* *********************** */

            Napredak.pokreniAkciju((Button)sender);

            /* *********************** */

            OleDbConnection MyConn = BazaPodataka.openConnectionToDatabase();

            /* *********************** */

            OleDbCommand komanda = new OleDbCommand("UPDATE Traktori SET [NazivTraktora]=@NazivTraktora, [StandardnaOpremaId]=@StandardnaOpremaId, [IdKabine]=@IdKabine, [UlaznaCijena]=@UlaznaCijena, [OpisTraktora]=@OpisTraktora WHERE [ID]=@ID;", MyConn);

            /* ********* */

            string tempStandardnaOpremaId = "";

            List<Oprema> tempStandardnaOpremaList = new List<Oprema>();

            foreach (Oprema oprema in StandardnaOpremaListBox.Items)
            {
                tempStandardnaOpremaId += oprema.idOpreme + " + ";

                tempStandardnaOpremaList.Add(oprema);
            }

            if (tempStandardnaOpremaId != "")
            {
                tempStandardnaOpremaId = tempStandardnaOpremaId.Remove(tempStandardnaOpremaId.Length - 3);
            }

            /* ********* */

            komanda.Parameters.AddWithValue("@NazivTraktora", NazivTraktoraTextBox.Text);
            komanda.Parameters.AddWithValue("@StandardnaOpremaId", tempStandardnaOpremaId);
            komanda.Parameters.AddWithValue("@IdKabine", ((Kabina)KabinaComboBox.SelectedItem).idKabine);
            komanda.Parameters.AddWithValue("@UlaznaCijena", UlaznaCijenaTextBox.Text);
            komanda.Parameters.AddWithValue("@OpisTraktora", OpisTraktoraTextBox.Text);

            int idTraktora = ((Traktor)((UrediTraktore)Owner).getPopisTraktora().SelectedItem).idTraktora;

            komanda.Parameters.AddWithValue("@ID", idTraktora.ToString());

            int rezultatKomande = komanda.ExecuteNonQuery();

            /* *********************** */

            int uredjivaniIndex = ((UrediTraktore)Owner).getPopisTraktora().SelectedIndex;

            ((UrediTraktore)Owner).getPopisTraktora().Items[uredjivaniIndex] = new Traktor(
                idTraktora,
                NazivTraktoraTextBox.Text,
                tempStandardnaOpremaList,
                (Kabina)KabinaComboBox.SelectedItem,
                tempCijenaTraktora,
                OpisTraktoraTextBox.Text
            );

            /* *********************** */

            BazaPodataka.closeConnectionToDatabase(MyConn);

            /* *********************** */

            Napredak.zavrsiAkciju((Button)sender);

            /* *********************** */

            this.Close();
        }
    }
}
