using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PonudaApp
{
    [Serializable]
    class Traktor
    {
        public int idTraktora { get; set; }
        public string nazivTraktora { get; set; }
        public List<Oprema> standardnaOprema { get; set; }
        public Kabina kabinaTraktora { get; set; }
        public decimal ulaznaCijena { get; set; }
        public string opisTraktora { get; set; }

        public Traktor()
        {
            this.idTraktora = -1;
            this.nazivTraktora = "";
            this.standardnaOprema = new List<Oprema>();
            this.kabinaTraktora = new Kabina();
            this.ulaznaCijena = 0;
            this.opisTraktora = "";
        }

        public Traktor(int idTraktora, string nazivTraktora, List<Oprema> standardnaOprema, Kabina kabinaTraktora, decimal ulaznaCijena, string opisTraktora)
        {
            this.idTraktora = idTraktora;
            this.nazivTraktora = nazivTraktora;
            this.standardnaOprema = standardnaOprema;
            this.kabinaTraktora = kabinaTraktora;
            this.ulaznaCijena = ulaznaCijena;
            this.opisTraktora = opisTraktora;
        }

        public override string ToString()
        {
            string tempStandardnaOprema = "";

            foreach (Oprema oprema in standardnaOprema) {
                tempStandardnaOprema += oprema.nazivOpreme + " + ";
            }

            if (tempStandardnaOprema != "")
            {
                tempStandardnaOprema = tempStandardnaOprema.Remove(tempStandardnaOprema.Length - 3);
            }

            return nazivTraktora + " | " + tempStandardnaOprema + " | " + kabinaTraktora.nazivKabine + " | " + ulaznaCijena + " kn" + " | " + opisTraktora;
        }
    }
}
