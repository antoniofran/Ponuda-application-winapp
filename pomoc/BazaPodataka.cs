using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace PonudaApp
{
    class BazaPodataka
    {

        public static OleDbConnection openConnectionToDatabase()
        {
            string ConnStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=files\\database\\PonudaDatabase.accdb";

            OleDbConnection MyConn = new OleDbConnection(ConnStr);

            MyConn.Open();

            return MyConn;
        }

        public static Kabina dohvatiKabinu(int index)
        {
            Kabina tempKabina = null;

            OleDbConnection MyConn = BazaPodataka.openConnectionToDatabase();

            OleDbCommand komanda = new OleDbCommand("SELECT * FROM Kabine WHERE [ID]=@ID", MyConn);

            komanda.Parameters.AddWithValue("@ID", index);

            OleDbDataReader dataSet = komanda.ExecuteReader();

            while (dataSet.Read())
            {
                tempKabina = new Kabina();

                tempKabina.idKabine = index;

                tempKabina.nazivKabine = dataSet["NazivKabine"].ToString();

                tempKabina.cijenaKabine = Convert.ToDecimal(dataSet["CijenaKabine"].ToString());

                tempKabina.opisKabine = dataSet["OpisKabine"].ToString();
            }

            dataSet.Close();

            BazaPodataka.closeConnectionToDatabase(MyConn);

            return tempKabina;
        }

        public static Oprema dohvatiOpremu(int index)
        {
            Oprema tempOprema = null;

            OleDbConnection MyConn = BazaPodataka.openConnectionToDatabase();

            OleDbCommand komanda = new OleDbCommand("SELECT * FROM Opreme WHERE [ID]=@ID", MyConn);

            komanda.Parameters.AddWithValue("@ID", index);

            OleDbDataReader dataSet = komanda.ExecuteReader();

            while (dataSet.Read())
            {
                tempOprema = new Oprema();

                tempOprema.idOpreme = index;

                tempOprema.nazivOpreme = dataSet["NazivOpreme"].ToString();

                tempOprema.kategorijaOpreme = dataSet["KategorijaOpreme"].ToString();

                tempOprema.cijenaOpreme = Convert.ToDecimal(dataSet["CijenaOpreme"].ToString());

                tempOprema.opisOpreme = dataSet["OpisOpreme"].ToString();
            }

            dataSet.Close();

            BazaPodataka.closeConnectionToDatabase(MyConn);

            return tempOprema;
        }

        public static Traktor dohvatiTraktor(int index)
        {
            Traktor tempTraktor = null;

            OleDbConnection MyConn = BazaPodataka.openConnectionToDatabase();

            OleDbCommand komanda = new OleDbCommand("SELECT * FROM Traktori WHERE [ID]=@ID", MyConn);

            komanda.Parameters.AddWithValue("@ID", index);

            OleDbDataReader dataSet = komanda.ExecuteReader();

            while (dataSet.Read())
            {
                tempTraktor = new Traktor();

                tempTraktor.idTraktora = index;

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
            }

            dataSet.Close();

            BazaPodataka.closeConnectionToDatabase(MyConn);

            return tempTraktor;
        }

        public static void closeConnectionToDatabase(OleDbConnection MyConn)
        {
            MyConn.Close();
        }

    }
}
