using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace PonudaApp
{
    class IzvozHtml
    {
        public static HtmlDocument otvoriHtmlDokument()
        {
            HtmlDocument htmlDokument = new HtmlDocument();

            htmlDokument.Load("files\\export\\template.html");

            return htmlDokument;
        }

        public static void izvozHtmlPonuda(Ponuda ponuda)
        {
            HtmlDocument htmlDokument = otvoriHtmlDokument();

            string tempTable = "";

            tempTable += "<table>";

            tempTable += "<tr><td><b>Traktor:</b></td>" + "<td>" + ponuda.traktorPonude.ToString() + "</td></tr>";

            /* *************************** */

            string tempPopisImenaOpreme = "";

            foreach (Oprema oprema in ponuda.dodatnaOprema)
            {
                tempPopisImenaOpreme += "<p>" + oprema.ToString() + "</p>";
            }

            /* *************************** */

            tempTable += "<tr><td><b>Dodatna oprema:</b></td>" + "<td>" + tempPopisImenaOpreme + "</td></tr>";

            tempTable += "<tr><td><b>Kabina:</b></td>" + "<td>" + ponuda.kabinaPonude.ToString() + "</td></tr>";

            tempTable += "<tr><td><b>Popust na iznos:</b></td>" + "<td>" + ponuda.popustNaIznosPostotak + "%" + "</td></tr>";

            tempTable += "<tr><td><b>Datum ponude:</b></td>" + "<td>" + ponuda.datumPonude.Date.ToShortDateString() + "</td></tr>";

            tempTable += "<tr><td><b>Napomena ponude:</b></td>" + "<td>" + ponuda.napomenaPonude + "</td></tr>";

            tempTable += "</table>";

            htmlDokument.GetElementbyId("test").InnerHtml = tempTable;

            spremiHtmlDokument(htmlDokument);

            otvoriHtmlDokument(htmlDokument);
        }

        public static void spremiHtmlDokument(HtmlDocument htmlDokument)
        {
            htmlDokument.Save("files\\export\\export.html");
        }

        public static void otvoriHtmlDokument(HtmlDocument htmlDokument)
        {
            System.Diagnostics.Process.Start(@"files\\export\\export.html");
        }
    }
}