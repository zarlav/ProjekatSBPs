using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatSBP.Entiteti
{
    public class PravnoLice : Klijent
    {
        public virtual string maticniBr { get; set; }
        public virtual string adresa { get; set; }
        public virtual string firma { get; set; }
        public virtual string delatnost { get; set; }
        public virtual IList<string> Telefoni { get; set; } = new List<string>();
        public virtual IList<string> EmailAdrese { get; set; } = new List<string>();
        public virtual string kontaktOsoba { get; set; }
        public virtual int pib { get; set; }
    }
}
