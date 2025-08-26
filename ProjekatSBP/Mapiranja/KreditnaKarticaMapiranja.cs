using FluentNHibernate.Mapping;
using NHibernate.Mapping;
using ProjekatSBP.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatSBP.Mapiranja
{
    public class KreditnaKarticaMapiranja : SubclassMap<KreditnaKartica>
    {
        public KreditnaKarticaMapiranja()
        {
            Table("KreditnaKartica");
            KeyColumn("KarticaID");  
            Map(x => x.MesecniLimit, "MesecniLimit");
            Map(x => x.MaxPeriodOtplate, "MaxPeriodOtplate");
        }
    }
}
