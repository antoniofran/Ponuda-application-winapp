using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PonudaApp
{
    [Serializable]
    class Ponuda
    {
        public int indexPonude { get; set; }
        public Traktor traktorPonude { get; set; }
        public List<Oprema> dodatnaOprema { get; set; }
        public Kabina kabinaPonude { get; set; }
        public decimal popustNaIznosPostotak { get; set; }
        public DateTime datumPonude { get; set; }
        public string napomenaPonude { get; set; }

        public Ponuda()
        {
            this.indexPonude = -1;
            this.traktorPonude = new Traktor();
            this.dodatnaOprema = new List<Oprema>();
            this.kabinaPonude = new Kabina();
            this.popustNaIznosPostotak = 0;
            this.datumPonude = DateTime.Now;
            this.napomenaPonude = "";
        }

        public Ponuda(Traktor traktorPonude, List<Oprema> dodatnaOprema, Kabina kabinaPonude, decimal popustNaIznosPostotak, DateTime datumPonude, string napomenaPonude)
        {
            this.traktorPonude = traktorPonude;
            this.dodatnaOprema = dodatnaOprema;
            this.kabinaPonude = kabinaPonude;
            this.popustNaIznosPostotak = popustNaIznosPostotak;
            this.datumPonude = datumPonude;
            this.napomenaPonude = napomenaPonude;
        }

        public Ponuda(int indexPonude, Traktor traktorPonude, List<Oprema> dodatnaOprema, Kabina kabinaPonude, decimal popustNaIznosPostotak, DateTime datumPonude, string napomenaPonude)
        {
            this.indexPonude = indexPonude;
            this.traktorPonude = traktorPonude;
            this.dodatnaOprema = dodatnaOprema;
            this.kabinaPonude = kabinaPonude;
            this.popustNaIznosPostotak = popustNaIznosPostotak;
            this.datumPonude = datumPonude;
            this.napomenaPonude = napomenaPonude;
        }

        public override string ToString()
        {
            string tempDodatnaOprema = "";

            foreach (Oprema oprema in dodatnaOprema)
            {
                tempDodatnaOprema += oprema.nazivOpreme + " + ";
            }

            if (tempDodatnaOprema != "")
            {
                tempDodatnaOprema = tempDodatnaOprema.Remove(tempDodatnaOprema.Length - 3);
            }

            return traktorPonude.nazivTraktora + " | " + tempDodatnaOprema + " | " + kabinaPonude.nazivKabine + " | " + popustNaIznosPostotak + "%" + " | " + datumPonude.Date.ToShortDateString() + " | " + napomenaPonude;
        }
    }
}
