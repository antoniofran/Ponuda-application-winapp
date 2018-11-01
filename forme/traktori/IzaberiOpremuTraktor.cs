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
    public partial class IzaberiOpremuTraktor : Form
    {
        public IzaberiOpremuTraktor()
        {
            InitializeComponent();
        }

        internal ListBox getStandardnaOpremaListBox()
        {
            return PopisStandardneOpreme;
        }

        private void IzaberiOpremuTraktor_Load(object sender, EventArgs e)
        {
            OleDbConnection MyConn = BazaPodataka.openConnectionToDatabase();

            /* ************************************ */

            string tempPopisKoristeneOpremeId = "";

            if (Owner is NoviTraktor)
            {
                foreach (Oprema oprema in ((NoviTraktor)Owner).getStandardnaOpremaListBox().Items)
                {
                    tempPopisKoristeneOpremeId += oprema.idOpreme.ToString() + ", ";
                }
            }

            if (Owner is UrediTraktor)
            {
                foreach (Oprema oprema in ((UrediTraktor)Owner).getStandardnaOpremaListBox().Items)
                {
                    tempPopisKoristeneOpremeId += oprema.idOpreme.ToString() + ", ";
                }
            }

            /* ************************************ */

            OleDbCommand komanda = null;

            if (tempPopisKoristeneOpremeId == "")
            {
                komanda = new OleDbCommand("SELECT * FROM Opreme;", MyConn);
            }
            else
            {
                tempPopisKoristeneOpremeId = tempPopisKoristeneOpremeId.Remove(tempPopisKoristeneOpremeId.Length - 2);

                komanda = new OleDbCommand("SELECT * FROM Opreme WHERE [ID] NOT IN (" + tempPopisKoristeneOpremeId + ");", MyConn);
            }

            /* ************************************ */

            OleDbDataReader dataSet = komanda.ExecuteReader();

            while (dataSet.Read())
            {
                Oprema tempOprema = new Oprema();

                tempOprema.idOpreme = Convert.ToInt32(dataSet["ID"].ToString());

                tempOprema.nazivOpreme = dataSet["NazivOpreme"].ToString();

                tempOprema.kategorijaOpreme = dataSet["KategorijaOpreme"].ToString();

                tempOprema.cijenaOpreme = Convert.ToDecimal(dataSet["CijenaOpreme"].ToString());

                tempOprema.opisOpreme = dataSet["OpisOpreme"].ToString();

                PopisStandardneOpreme.Items.Add(tempOprema);
            }

            dataSet.Close();

            BazaPodataka.closeConnectionToDatabase(MyConn);
        }

        private void IzaberiGumb_Click(object sender, EventArgs e)
        {
            if (PopisStandardneOpreme.SelectedItem != null)
            {
                Napredak.pokreniAkciju((Button)sender);

                if (Owner is NoviTraktor)
                {
                    ((NoviTraktor)Owner).getStandardnaOpremaListBox().Items.Add(PopisStandardneOpreme.SelectedItem);
                }

                if (Owner is UrediTraktor)
                {
                    ((UrediTraktor)Owner).getStandardnaOpremaListBox().Items.Add(PopisStandardneOpreme.SelectedItem);
                }

                Napredak.zavrsiAkciju((Button)sender);

                this.Close();
            }
            else
            {
                MessageBox.Show("Prvo se treba selektirati oprema.", "Alert", MessageBoxButtons.OK);
            }
        }

        private void DodajNovuOpremuGumb_Click(object sender, EventArgs e)
        {
            Napredak.pokreniAkciju((Button)sender);
            
            NovaOprema novaOprema = new NovaOprema();

            novaOprema.Owner = this;

            novaOprema.ShowDialog();

            Napredak.zavrsiAkciju((Button)sender);
        }
    }
}
