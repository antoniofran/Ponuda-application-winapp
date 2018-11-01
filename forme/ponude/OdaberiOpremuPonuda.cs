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
    public partial class OdaberiOpremuPonuda : Form
    {
        public OdaberiOpremuPonuda()
        {
            InitializeComponent();
        }

        internal ListBox getDodatneOpremeListBox()
        {
            return PopisDodatneOpreme;
        }

        private void OdaberiOpremuPonuda_Load(object sender, EventArgs e)
        {

            OleDbConnection MyConn = BazaPodataka.openConnectionToDatabase();

            /* ************************************ */

            string tempPopisKoristeneOpremeId = "";

            if (Owner is NovaPonuda)
            {
                foreach (Oprema oprema in ((Traktor)((NovaPonuda)Owner).getTraktoriComboBox().SelectedItem).standardnaOprema)
                {
                    tempPopisKoristeneOpremeId += oprema.idOpreme.ToString() + ", ";
                }

                foreach (Oprema oprema in ((NovaPonuda)Owner).getPopisDodatneOpremeListBox().Items)
                {
                    tempPopisKoristeneOpremeId += oprema.idOpreme.ToString() + ", ";
                }
            }

            if (Owner is UrediPonudu)
            {
                foreach (Oprema oprema in ((Traktor)((UrediPonudu)Owner).getTraktoriComboBox().SelectedItem).standardnaOprema)
                {
                    tempPopisKoristeneOpremeId += oprema.idOpreme.ToString() + ", ";
                }

                foreach (Oprema oprema in ((UrediPonudu)Owner).getPopisDodatneOpremeListBox().Items)
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

                PopisDodatneOpreme.Items.Add(tempOprema);
            }

            dataSet.Close();

            BazaPodataka.closeConnectionToDatabase(MyConn);
        }

        private void IzaberiGumb_Click(object sender, EventArgs e)
        {
            if (PopisDodatneOpreme.SelectedItem != null)
            {
                Napredak.pokreniAkciju((Button)sender);

                if (Owner is NovaPonuda)
                {
                    ((NovaPonuda)Owner).getPopisDodatneOpremeListBox().Items.Add(PopisDodatneOpreme.SelectedItem);
                }

                if (Owner is UrediPonudu)
                {
                    ((UrediPonudu)Owner).getPopisDodatneOpremeListBox().Items.Add(PopisDodatneOpreme.SelectedItem);
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
