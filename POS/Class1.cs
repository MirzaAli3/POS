using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS
{
    public class Artikal
    {
        public string Sifra { get; set; }
        public string Naziv { get; set; }
        public int Kolicina { get; set; }
        public int Ucena { get; set; }
        public int Marza { get; set; }
        public int PDV { get; set; }  
        public int Cena { get; set; }
    }
}
