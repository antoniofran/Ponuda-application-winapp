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
    public partial class UrediTraktore : Form
    {
        public UrediTraktore()
        {
            InitializeComponent();
        }

        internal ListBox getPopisTraktora()
        {
            return PopisTraktora;
        }

        private void UrediTraktore_Load(object sender, EventArgs e)
        {
            OleDbConnection MyConn = BazaPodataka.openConnectionToDatabase();

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

                PopisTraktora.Items.Add(tempTraktor);
            }

            dataSet.Close();

            BazaPodataka.closeConnectionToDatabase(MyConn);
        }

        private void UrediTraktorGumb_Click(object sender, EventArgs e)
        {
            if (PopisTraktora.SelectedItem != null)
            {
                Napredak.pokreniAkciju((Button)sender);
                
                UrediTraktor urediTraktor = new UrediTraktor();

                urediTraktor.Owner = this;

                urediTraktor.ShowDialog();

                Napredak.zavrsiAkciju((Button)sender);
            }
            else
            {
                MessageBox.Show("Prvo se treba selektirati oprema.", "Alert", MessageBoxButtons.OK);
            }
        }

        private void IzbrisiTraktorGumb_Click(object sender, EventArgs e)
        {
            if (PopisTraktora.SelectedItem != null)
            {
                if (MessageBox.Show("Nakon brisanja, selektirani traktor se više neće prikazati prilikom uređivanja ponude koja ju referira. Sigurno obrisati?", "Confirm", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    Napredak.pokreniAkciju((Button)sender);

                    OleDbConnection MyConn = BazaPodataka.openConnectionToDatabase();

                    OleDbCommand komanda = new OleDbCommand("DELETE FROM Traktori WHERE [ID]=@ID", MyConn);

                    komanda.Parameters.AddWithValue("@ID", ((Traktor)PopisTraktora.SelectedItem).idTraktora.ToString());

                    int rezultatKomande = komanda.ExecuteNonQuery();

                    PopisTraktora.Items.Remove(PopisTraktora.SelectedItem);

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
