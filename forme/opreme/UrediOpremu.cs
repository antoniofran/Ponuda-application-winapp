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
    public partial class UrediOpremu : Form
    {

        public UrediOpremu()
        {
            InitializeComponent();

        }

        internal ComboBox getKategorijaOpremeComboBox()
        {
            return KategorijaOpremeComboBox;
        }
          
        private void UrediOpremu_Load(object sender, EventArgs e)
        {
            OleDbConnection MyConn = BazaPodataka.openConnectionToDatabase();

            /* ***************** */

            OleDbCommand komanda = new OleDbCommand("SELECT DISTINCT KategorijaOpreme FROM Opreme;", MyConn);

            OleDbDataReader dataSet = komanda.ExecuteReader();

            while (dataSet.Read())
            {
                KategorijaOpremeComboBox.Items.Add(dataSet["KategorijaOpreme"].ToString());
            }

            dataSet.Close();

            /* ***************** */

            OleDbCommand komanda2 = new OleDbCommand("SELECT * FROM Opreme WHERE [ID]=@ID;", MyConn);

            komanda2.Parameters.AddWithValue("@ID", ((Oprema)((UrediOpreme)Owner).getPopisOprema().SelectedItem).idOpreme.ToString());

            OleDbDataReader dataSet2 = komanda2.ExecuteReader();

            while (dataSet2.Read())
            {
                NazivOpremeTextBox.Text = dataSet2["NazivOpreme"].ToString();
                KategorijaOpremeComboBox.SelectedItem = dataSet2["KategorijaOpreme"].ToString();
                CijenaOpremeTextBox.Text = dataSet2["CijenaOpreme"].ToString();
                OpisOpremeTextBox.Text = dataSet2["OpisOpreme"].ToString();
            }

            dataSet2.Close();

            /* ***************** */

            BazaPodataka.closeConnectionToDatabase(MyConn);
        }

        private void NovaKategorijaGumb_Click(object sender, EventArgs e)
        {
            Napredak.pokreniAkciju((Button)sender);
            
            NovaKategorijaOprema novaKategorijaGumb = new NovaKategorijaOprema();

            novaKategorijaGumb.Owner = this;

            novaKategorijaGumb.ShowDialog();

            Napredak.zavrsiAkciju((Button)sender);
        }

        private void SpremiOpremuGumb_Click(object sender, EventArgs e)
        {
            if (NazivOpremeTextBox.Text == string.Empty || KategorijaOpremeComboBox.SelectedItem == null || CijenaOpremeTextBox.Text == string.Empty || OpisOpremeTextBox.Text == string.Empty)
            {
                MessageBox.Show("Sva polja moraju biti popunjena.", "Alert", MessageBoxButtons.OK);
                return;
            }

            decimal tempCijenaOpreme = 0;

            CijenaOpremeTextBox.Text = CijenaOpremeTextBox.Text.Replace(".", ",");

            if (!decimal.TryParse(CijenaOpremeTextBox.Text, out tempCijenaOpreme))
            {
                MessageBox.Show("Cijena opreme mora biti broj.", "Alert", MessageBoxButtons.OK);
                return;
            }

            /* **************************** */

            Napredak.pokreniAkciju((Button)sender);

            /* **************************** */

            OleDbConnection MyConn = BazaPodataka.openConnectionToDatabase();

            /* *********************** */

            OleDbCommand komanda = new OleDbCommand("UPDATE Opreme SET [NazivOpreme]=@NazivOpreme, [KategorijaOpreme]=@KategorijaOpreme, [CijenaOpreme]=@CijenaOpreme, [OpisOpreme]=@OpisOpreme WHERE [ID]=@ID;", MyConn);

            komanda.Parameters.AddWithValue("@NazivOpreme", NazivOpremeTextBox.Text);
            komanda.Parameters.AddWithValue("@KategorijaOpreme", KategorijaOpremeComboBox.SelectedItem.ToString());
            komanda.Parameters.AddWithValue("@CijenaOpreme", CijenaOpremeTextBox.Text);
            komanda.Parameters.AddWithValue("@OpisOpreme", OpisOpremeTextBox.Text);

            int idOpreme = ((Oprema)((UrediOpreme)Owner).getPopisOprema().SelectedItem).idOpreme;

            komanda.Parameters.AddWithValue("@ID", idOpreme.ToString());

            int rezultatKomande = komanda.ExecuteNonQuery();

            /* *********************** */

            int uredjivaniIndex = ((UrediOpreme)Owner).getPopisOprema().SelectedIndex;

            ((UrediOpreme)Owner).getPopisOprema().Items[uredjivaniIndex] = new Oprema(
                idOpreme,
                NazivOpremeTextBox.Text,
                KategorijaOpremeComboBox.SelectedItem.ToString(),
                tempCijenaOpreme,
                OpisOpremeTextBox.Text
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
