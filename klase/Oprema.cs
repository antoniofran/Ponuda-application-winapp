using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PonudaApp
{
    [Serializable]
    class Oprema
    {
        public int idOpreme { get; set; }
        public string nazivOpreme { get; set; }
        public string kategorijaOpreme { get; set; }
        public decimal cijenaOpreme { get; set; }
        public string opisOpreme { get; set; }

        public Oprema()
        {
            this.idOpreme = -1;
            this.nazivOpreme = "";
            this.kategorijaOpreme = "";
            this.cijenaOpreme = 0;
            this.opisOpreme = "";
        }

        public Oprema(int idOpreme, string nazivOpreme, string kategorijaOpreme, decimal cijenaOpreme, string opisOpreme) {
            this.idOpreme = idOpreme;
            this.nazivOpreme = nazivOpreme;
            this.kategorijaOpreme = kategorijaOpreme;
            this.cijenaOpreme = cijenaOpreme;
            this.opisOpreme = opisOpreme;
        }

        public override string ToString()
        {
            return nazivOpreme + " | " + kategorijaOpreme + " | " + cijenaOpreme + " kn" + " | " + opisOpreme;
        }
    }
}
