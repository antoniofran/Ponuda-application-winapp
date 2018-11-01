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
    public partial class NovaOprema : Form
    {
        public NovaOprema()
        {
            InitializeComponent();
        }

        internal ComboBox getKategorijaOpremeComboBox()
        {
            return KategorijaOpremeComboBox;
        }

        private void NovaOprema_Load(object sender, EventArgs e)
        {
            OleDbConnection MyConn = BazaPodataka.openConnectionToDatabase();

            OleDbCommand komanda = new OleDbCommand("SELECT DISTINCT KategorijaOpreme FROM Opreme;", MyConn);

            OleDbDataReader dataSet = komanda.ExecuteReader();

            while (dataSet.Read())
            {
                KategorijaOpremeComboBox.Items.Add( dataSet["KategorijaOpreme"].ToString() );
            }

            dataSet.Close();

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

            /* ********************* */

            OleDbCommand komanda = new OleDbCommand("INSERT INTO Opreme([NazivOpreme], [KategorijaOpreme], [CijenaOpreme], [OpisOpreme]) VALUES(@NazivOpreme, @KategorijaOpreme, @CijenaOpreme, @OpisOpreme);", MyConn);

            komanda.Parameters.AddWithValue("@NazivOpreme", NazivOpremeTextBox.Text);
            komanda.Parameters.AddWithValue("@KategorijaOpreme", KategorijaOpremeComboBox.SelectedItem.ToString());
            komanda.Parameters.AddWithValue("@CijenaOpreme", CijenaOpremeTextBox.Text);
            komanda.Parameters.AddWithValue("@OpisOpreme", OpisOpremeTextBox.Text);

            int rezultatKomande = komanda.ExecuteNonQuery();

            /* ********************* */

            OleDbCommand komanda2 = new OleDbCommand("SELECT MAX([ID]) FROM Opreme;", MyConn);

            int tempIdOpreme = (int)komanda2.ExecuteScalar();

            /* ********************* */

            BazaPodataka.closeConnectionToDatabase(MyConn);

            /* ********************* */

            if (Owner is IzaberiOpremuTraktor)
            {
                ListBox tempKategorijaOpremeComboBox = ((IzaberiOpremuTraktor)Owner).getStandardnaOpremaListBox();

                tempKategorijaOpremeComboBox.Items.Add( new Oprema(
                    tempIdOpreme,
                    NazivOpremeTextBox.Text,
                    KategorijaOpremeComboBox.SelectedItem.ToString(),
                    tempCijenaOpreme,
                    OpisOpremeTextBox.Text
                ) );

                tempKategorijaOpremeComboBox.SelectedIndex = tempKategorijaOpremeComboBox.Items.Count - 1;
            }

            if (Owner is OdaberiOpremuPonuda)
            {
                ListBox tempKategorijaOpremeComboBox = ((OdaberiOpremuPonuda)Owner).getDodatneOpremeListBox();

                tempKategorijaOpremeComboBox.Items.Add(new Oprema(
                    tempIdOpreme,
                    NazivOpremeTextBox.Text,
                    KategorijaOpremeComboBox.SelectedItem.ToString(),
                    tempCijenaOpreme,
                    OpisOpremeTextBox.Text
                ));

                tempKategorijaOpremeComboBox.SelectedIndex = tempKategorijaOpremeComboBox.Items.Count - 1;
            }

            /* ********************* */

            Napredak.zavrsiAkciju((Button)sender);

            /* ********************* */

            this.Close();
        }
    }
}
