using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatSBP.Entiteti
{
    public class Klijent
    {
        public enum TipKlijenta
        {
            pravno,
            fizicko,
            organizacija
        }
        public virtual int id { get; set; }
        public virtual TipKlijenta tip { get; set; }
        public virtual IList<Racun> racuni { get; set; }

        public Klijent()
        {
            racuni = new List<Racun>();
        }
    }
}
