using FluentNHibernate.Conventions.Inspections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatSBP.Entiteti
{
    public class DebitnaKartica : Kartica
    {
        public virtual decimal DnevniLimitZaPodizanje { get; set; }
    }
}
