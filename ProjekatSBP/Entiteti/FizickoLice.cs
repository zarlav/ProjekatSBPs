using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatSBP.Entiteti
{
    public class FizickoLice : Klijent
    {
        public virtual string adresa { get; set; }
        public virtual DateTime datumRodj { get; set; }
        public virtual string brLicneKarte { get; set; }
        public virtual string mestoIzdavanja { get; set; }
        public virtual string jmbg { get; set; }
        public virtual IList<string> Telefoni { get; set; } = new List<string>();
        public virtual string prezime { get; set; }
        public virtual string imeRoditelja { get; set; }
        public virtual string licnoIme { get; set; }
    }
}
