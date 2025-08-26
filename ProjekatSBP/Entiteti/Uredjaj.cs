using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatSBP.Entiteti
{
    public enum StatusRada
    {
        Operativan,
        TestRezim,
        Neoperativan
    };
    public class Uredjaj
    {
        public virtual int Id { get; set; } 
        public virtual String Adresa { get; set; }
        public virtual string Proizvodjac { get; set; }
        public virtual string Komentar { get; set; }
        public virtual StatusRada Status { get; set; }
        public virtual DateTime DatumInstalacije { get; set; }
        public virtual DateTime? DatumServisa { get; set; } 
        public virtual double GeogrSirina { get; set; }    
        public virtual double GeogrDuzina { get; set; }
        public virtual IList<Filijala> Filijale { get; set; }

        public virtual Banka PripadaBanci {get; set;}
        public Uredjaj()
        {
            Filijale = new List<Filijala>();
        }

    }
}
