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
    public partial class UrediKabinu : Form
    {
        public UrediKabinu()
        {
            InitializeComponent();
        }

        private void UrediKabinu_Load(object sender, EventArgs e)
        {
            OleDbConnection MyConn = BazaPodataka.openConnectionToDatabase();

            OleDbCommand komanda = new OleDbCommand("SELECT * FROM Kabine WHERE [ID]=@ID;", MyConn);

            komanda.Parameters.AddWithValue("@ID", ((Kabina)((UrediKabine)Owner).getPopisKabina().SelectedItem).idKabine.ToString());

            OleDbDataReader dataSet = komanda.ExecuteReader();

            while (dataSet.Read())
            {
                NazivKabineTextBox.Text = dataSet["NazivKabine"].ToString();
                CijenaKabineTextBox.Text = dataSet["CijenaKabine"].ToString();
                OpisKabineTextBox.Text = dataSet["OpisKabine"].ToString();
            }

            dataSet.Close();

            BazaPodataka.closeConnectionToDatabase(MyConn);
        }

        private void SpremiKabinuGumb_Click(object sender, EventArgs e)
        {
            if (NazivKabineTextBox.Text == string.Empty || CijenaKabineTextBox.Text == string.Empty || OpisKabineTextBox.Text == string.Empty)
            {
                MessageBox.Show("Sva polja moraju biti popunjena.", "Alert", MessageBoxButtons.OK);
                return;
            }

            decimal tempCijenaKabine = 0;

            CijenaKabineTextBox.Text = CijenaKabineTextBox.Text.Replace(".", ",");

            if (!decimal.TryParse(CijenaKabineTextBox.Text, out tempCijenaKabine))
            {
                MessageBox.Show("Cijena kabine mora biti broj.", "Alert", MessageBoxButtons.OK);
                return;
            }

            /* *********************** */

            Napredak.pokreniAkciju((Button)sender);

            /* *********************** */

            OleDbConnection MyConn = BazaPodataka.openConnectionToDatabase();

            /* *********************** */

            OleDbCommand komanda = new OleDbCommand("UPDATE Kabine SET [NazivKabine]=@NazivKabine, [CijenaKabine]=@CijenaKabine, [OpisKabine]=@OpisKabine WHERE [ID]=@ID;", MyConn);

            komanda.Parameters.AddWithValue("@NazivKabine", NazivKabineTextBox.Text);
            komanda.Parameters.AddWithValue("@CijenaKabine", CijenaKabineTextBox.Text);
            komanda.Parameters.AddWithValue("@OpisKabine", OpisKabineTextBox.Text);

            int idKabine = ((Kabina)((UrediKabine)Owner).getPopisKabina().SelectedItem).idKabine;

            komanda.Parameters.AddWithValue("@ID", idKabine.ToString());

            int rezultatKomande = komanda.ExecuteNonQuery();

            /* *********************** */

            int uredjivaniIndex = ((UrediKabine)Owner).getPopisKabina().SelectedIndex;

            ((UrediKabine)Owner).getPopisKabina().Items[uredjivaniIndex] = new Kabina(
                idKabine,
                NazivKabineTextBox.Text,
                tempCijenaKabine,
                OpisKabineTextBox.Text
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
