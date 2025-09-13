using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatSBP.Entiteti
{
    public class KreditnaKartica : Kartica
    {
        public virtual int MaxPeriodOtplate { get; set; }
        public virtual decimal MesecniLimit { get; set; }
    }
}
