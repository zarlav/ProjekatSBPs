using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatSBP.Entiteti
{
    public class Banka
    {
        public virtual int Id { get; set; }
        public virtual string Naziv { get; set; }
        public virtual string Adresa { get; set; }
        public virtual string WebAdresa { get; set; }
        public virtual IList<string> Telefoni { get; set; } = new List<string>();
        public virtual IList<string> EmailAdrese { get; set; } = new List<string>();
        public virtual IList<Uredjaj> Uredjaji { get; set; }
        public virtual IList<Filijala> Filijale { get; set; }
        public Banka()
        {
            Telefoni = new List<string>();
            EmailAdrese = new List<string>();
            Uredjaji = new List<Uredjaj>();
            Filijale = new List<Filijala>();
        }
    }
}
