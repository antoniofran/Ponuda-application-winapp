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
    public partial class UrediKabine : Form
    {
        public UrediKabine()
        {
            InitializeComponent();
        }

        internal ListBox getPopisKabina()
        {
            return PopisKabina;
        }

        private void UrediKabine_Load(object sender, EventArgs e)
        {
            OleDbConnection MyConn = BazaPodataka.openConnectionToDatabase();

            OleDbCommand komanda = new OleDbCommand("SELECT * FROM Kabine", MyConn);

            OleDbDataReader dataSet = komanda.ExecuteReader();

            while (dataSet.Read())
            {
                Kabina tempKabina = new Kabina();

                tempKabina.idKabine = Convert.ToInt32(dataSet["ID"].ToString());

                tempKabina.nazivKabine = dataSet["NazivKabine"].ToString();

                tempKabina.cijenaKabine = Convert.ToDecimal(dataSet["CijenaKabine"].ToString());

                tempKabina.opisKabine = dataSet["OpisKabine"].ToString();

                PopisKabina.Items.Add(tempKabina);
            }

            dataSet.Close();

            BazaPodataka.closeConnectionToDatabase(MyConn);
        }

        private void UrediKabinuGumb_Click(object sender, EventArgs e)
        {

            if (PopisKabina.SelectedItem != null)
            {
                Napredak.pokreniAkciju((Button)sender);

                UrediKabinu urediKabinu = new UrediKabinu();

                urediKabinu.Owner = this;

                urediKabinu.ShowDialog();

                Napredak.zavrsiAkciju((Button)sender);
            }
            else
            {
                MessageBox.Show("Prvo se treba selektirati kabina.", "Alert", MessageBoxButtons.OK);
            }
        }

        private void IzbrisiKabinuGumb_Click(object sender, EventArgs e)
        {
            if (PopisKabina.SelectedItem != null)
            {
                if (MessageBox.Show("Nakon brisanja, selektirana kabina se više neće prikazati prilikom uređivanja traktora/ponude koja ju referira. Sigurno obrisati?", "Confirm", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    Napredak.pokreniAkciju((Button)sender);

                    OleDbConnection MyConn = BazaPodataka.openConnectionToDatabase();

                    OleDbCommand komanda = new OleDbCommand("DELETE FROM Kabine WHERE [ID]=@ID", MyConn);

                    komanda.Parameters.AddWithValue("@ID", ((Kabina)PopisKabina.SelectedItem).idKabine.ToString());

                    int rezultatKomande = komanda.ExecuteNonQuery();

                    PopisKabina.Items.Remove(PopisKabina.SelectedItem);

                    BazaPodataka.closeConnectionToDatabase(MyConn);

                    Napredak.zavrsiAkciju((Button)sender);
                }
            }
            else
            {
                MessageBox.Show("Prvo se treba selektirati kabina.", "Alert", MessageBoxButtons.OK);
            }
        }

    }
}
