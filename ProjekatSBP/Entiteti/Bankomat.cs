using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatSBP.Entiteti
{
    public class Bankomat : Uredjaj
    {
        public virtual double MaxIznos { get; set; }
        public virtual IList<BrojNovcanicaUBankomat> brojNovcanica { get; set; } = new List<BrojNovcanicaUBankomat>();

        

    }
}
