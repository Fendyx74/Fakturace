using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fakturace.Model
{
    public class Odberatel
    {
        public int Id { get; set; }
        public int Id2 { get; set; }
        public string Jmeno { get; set; }
        public string Prijmeni { get; set; }
        public string Zeme { get; set; }
        public string Mesto { get; set; }
        public string Ulice { get; set; }
        public string CisloPopisne { get; set; }
        public string Psc { get; set; }
        public string Ico { get; set; }
        public string Produkty { get; set; }

        public Odberatel(int id2, string jmeno, string prijmeni, string zeme, string mesto, string ulice, string cisloPopisne, string psc, string ico, string produkty)
        {
            Id2 = id2;
            Jmeno = jmeno;
            Prijmeni = prijmeni;
            Zeme = zeme;
            Mesto = mesto;
            Ulice = ulice;
            CisloPopisne = cisloPopisne;
            Psc = psc;
            Ico = ico;
            Produkty = produkty;
        }

        public override string ToString() => $"Odběratel: {Id2}. - {Jmeno} {Prijmeni}";
    }
}
