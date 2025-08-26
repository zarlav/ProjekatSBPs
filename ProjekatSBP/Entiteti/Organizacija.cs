using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatSBP.Entiteti
{
    public class Organizacija : Klijent
    {
        public virtual string tipOrganizacije { get; set; }
        public virtual string osnivac { get; set; }
        public virtual string adresa { get; set; }
        public virtual string registar { get; set; }
        public virtual IList<string> Telefoni { get; set; } = new List<string>();
        public virtual IList<string> EmailAdrese { get; set; } = new List<string>();
    }
}
