using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatSBP.Entiteti
{
    public class Filijala
    {
        public virtual int Id { get; protected set; } 
        public virtual int RedniBrUBanci { get; set; }  
        public virtual string Adresa { get; set; }
        public virtual Banka SastojiSeOd { get; set; }
        public virtual IList<string> Telefoni { get; set; } = new List<string>();
        public virtual IList<Uredjaj> Uredjaji { get; set; } = new List<Uredjaj>();
        public virtual IList<RadnoVreme> RadnaVremena { get; set; } = new List<RadnoVreme>();
        public Filijala()
        {
        }

    }
}
