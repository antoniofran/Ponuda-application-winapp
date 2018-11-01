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
    public partial class UrediOpreme : Form
    {
        public UrediOpreme()
        {
            InitializeComponent();
        }

        internal ListBox getPopisOprema()
        {
            return PopisOprema;
        }

        private void UrediOpreme_Load(object sender, EventArgs e)
        {
            OleDbConnection MyConn = BazaPodataka.openConnectionToDatabase();

            OleDbCommand komanda = new OleDbCommand("SELECT * FROM Opreme", MyConn);

            OleDbDataReader dataSet = komanda.ExecuteReader();

            while (dataSet.Read())
            {
                Oprema tempOprema = new Oprema();

                tempOprema.idOpreme = Convert.ToInt32(dataSet["ID"].ToString());

                tempOprema.nazivOpreme = dataSet["NazivOpreme"].ToString();

                tempOprema.kategorijaOpreme = dataSet["KategorijaOpreme"].ToString();

                tempOprema.cijenaOpreme = Convert.ToDecimal(dataSet["CijenaOpreme"].ToString());

                tempOprema.opisOpreme = dataSet["OpisOpreme"].ToString();

                PopisOprema.Items.Add(tempOprema);
            }

            dataSet.Close();

            BazaPodataka.closeConnectionToDatabase(MyConn);
        }

        private void UrediOpremuGumb_Click(object sender, EventArgs e)
        {
            if (PopisOprema.SelectedItem != null)
            {
                Napredak.pokreniAkciju((Button)sender);

                UrediOpremu urediOpremu = new UrediOpremu();

                urediOpremu.Owner = this;

                urediOpremu.ShowDialog();

                Napredak.zavrsiAkciju((Button)sender);
            }
            else
            {
                MessageBox.Show("Prvo se treba selektirati oprema.", "Alert", MessageBoxButtons.OK);
            }
        }

        private void IzbrisiOpremuGumb_Click(object sender, EventArgs e)
        {
            if (PopisOprema.SelectedItem != null)
            {
                if (MessageBox.Show("Nakon brisanja, selektirana oprema se više neće prikazati prilikom uređivanja traktora/ponude koja ju referira. Sigurno obrisati?", "Confirm", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    Napredak.pokreniAkciju((Button)sender);

                    OleDbConnection MyConn = BazaPodataka.openConnectionToDatabase();

                    OleDbCommand komanda = new OleDbCommand("DELETE FROM Opreme WHERE [ID]=@ID", MyConn);

                    komanda.Parameters.AddWithValue("@ID", ((Oprema)PopisOprema.SelectedItem).idOpreme.ToString());

                    int rezultatKomande = komanda.ExecuteNonQuery();

                    PopisOprema.Items.Remove(PopisOprema.SelectedItem);

                    BazaPodataka.closeConnectionToDatabase(MyConn);

                    Napredak.zavrsiAkciju((Button)sender);
                }
            }
            else
            {
                MessageBox.Show("Prvo se treba selektirati oprema.", "Alert", MessageBoxButtons.OK);
            }
        }
    }
}
