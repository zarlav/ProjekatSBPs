using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatSBP.Entiteti
{
    public enum VrstaTransakcije
    {
        Podizanje,
        Uplata,
        ProveraStanja,
        PromenaPina
    };
    public class Transakcija
    {
        public virtual int TransakcijaId { get; set; }
        public virtual decimal Iznos { get; set; }
        public virtual string Valuta { get; set; }
        public virtual string RazlogNeuspeha { get; set; }
        public virtual DateTime DatumVreme { get; set; }
        public virtual string Status {  get; set; }
        public virtual VrstaTransakcije Vrsta { get; set; } 
        public virtual Kartica Kartica { get; set; }
        public virtual Uredjaj Uredjaj { get; set; }
    }
}
