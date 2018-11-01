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
    public partial class NovaKabina : Form
    {
        public NovaKabina()
        {
            InitializeComponent();
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

            if ( !decimal.TryParse(CijenaKabineTextBox.Text, out tempCijenaKabine) )
            {
                MessageBox.Show("Cijena kabine mora biti broj.", "Alert", MessageBoxButtons.OK);
                return;
            }

            /* ********************* */

            Napredak.pokreniAkciju((Button)sender);

            /* ********************* */

            OleDbConnection MyConn = BazaPodataka.openConnectionToDatabase();

            /* ********************* */

            OleDbCommand komanda = new OleDbCommand("INSERT INTO Kabine([NazivKabine], [CijenaKabine], [OpisKabine]) VALUES(@NazivKabine, @CijenaKabine, @OpisKabine);", MyConn);

            komanda.Parameters.AddWithValue("@NazivOpreme", NazivKabineTextBox.Text);
            komanda.Parameters.AddWithValue("@CijenaOpreme", CijenaKabineTextBox.Text);
            komanda.Parameters.AddWithValue("@OpisOpreme", OpisKabineTextBox.Text);

            int rezultatKomande = komanda.ExecuteNonQuery();

            /* ********************* */

            OleDbCommand komanda2 = new OleDbCommand("SELECT MAX([ID]) FROM Kabine;", MyConn);

            int tempIdKabine = (int)komanda2.ExecuteScalar();

            /* ********************* */

            BazaPodataka.closeConnectionToDatabase(MyConn);

            /* ********************************* */

            if (Owner is NoviTraktor)
            {
                ComboBox tempKabinaComboBox = ((NoviTraktor)Owner).getKabinaComboBox();

                Kabina tempKabina = new Kabina(
                    tempIdKabine,
                    NazivKabineTextBox.Text,
                    tempCijenaKabine,
                    OpisKabineTextBox.Text
                );

                tempKabinaComboBox.Items.Add(tempKabina);

                /* *********************************** */

                Form tempSedondLevelForma = ((NoviTraktor)Owner).Owner;

                if ( tempSedondLevelForma is NovaPonuda )
                {
                    ((NovaPonuda)tempSedondLevelForma).getKabinaComboBox().Items.Add(tempKabina);
                }

                /* *********************************** */

                tempKabinaComboBox.SelectedIndex = tempKabinaComboBox.Items.Count - 1;
            }

            if (Owner is UrediTraktor)
            {
                ComboBox tempKabinaComboBox = ((UrediTraktor)Owner).getKabinaComboBox();

                tempKabinaComboBox.Items.Add( new Kabina(
                    tempIdKabine,
                    NazivKabineTextBox.Text,
                    tempCijenaKabine,
                    OpisKabineTextBox.Text
                ) );

                tempKabinaComboBox.SelectedIndex = tempKabinaComboBox.Items.Count - 1;
            }

            /* ********************************* */

            if (Owner is NovaPonuda)
            {
                ComboBox tempKabinaComboBox = ((NovaPonuda)Owner).getKabinaComboBox();

                tempKabinaComboBox.Items.Add(new Kabina(
                    tempIdKabine,
                    NazivKabineTextBox.Text,
                    tempCijenaKabine,
                    OpisKabineTextBox.Text
                ));

                tempKabinaComboBox.SelectedIndex = tempKabinaComboBox.Items.Count - 1;
            }

            if (Owner is UrediPonudu)
            {
                ComboBox tempKabinaComboBox = ((UrediPonudu)Owner).getKabinaComboBox();

                tempKabinaComboBox.Items.Add(new Kabina(
                    tempIdKabine,
                    NazivKabineTextBox.Text,
                    tempCijenaKabine,
                    OpisKabineTextBox.Text
                ));

                tempKabinaComboBox.SelectedIndex = tempKabinaComboBox.Items.Count - 1;
            }

            /* ********************************* */

            Napredak.zavrsiAkciju((Button)sender);

            /* ********************************* */

            this.Close();
        }
    }
}
