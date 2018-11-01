using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PonudaApp
{
    class PonudaDat
    {
        public static void serijalizirajListuPonuda(List<Ponuda> ponudaList)
        {
            using (Stream stream = File.Open("files\\objekti\\ponudaList.dat", FileMode.Create))
            {
                var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                bformatter.Serialize(stream, ponudaList);
            }
        }

        public static List<Ponuda> deSerijalizirajListuPonuda()
        {
            List<Ponuda> ponudaList = new List<Ponuda>();

            using (Stream stream = File.Open("files\\objekti\\ponudaList.dat", FileMode.Open))
            {
                var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                ponudaList = (List<Ponuda>)bformatter.Deserialize(stream);
            }

            return ponudaList;
        }
    }
}
