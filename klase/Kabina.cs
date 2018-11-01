using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PonudaApp
{
    [Serializable]
    class Kabina
    {
        public int idKabine { get; set; }
        public string nazivKabine { get; set; }
        public decimal cijenaKabine { get; set; }
        public string opisKabine { get; set; }

        public Kabina()
        {
            this.idKabine = -1;
            this.nazivKabine = "";
            this.cijenaKabine = 0;
            this.opisKabine = "";
        }

        public Kabina(int idKabine, string nazivKabine, decimal cijenaKabine, string opisKabine)
        {
            this.idKabine = idKabine;
            this.nazivKabine = nazivKabine;
            this.cijenaKabine = cijenaKabine;
            this.opisKabine = opisKabine;
        }

        public override string ToString()
        {
            return nazivKabine + " | " + cijenaKabine + " kn" + " | " + opisKabine;
        }
    }
}
