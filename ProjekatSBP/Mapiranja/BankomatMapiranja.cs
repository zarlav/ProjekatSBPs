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
    public class BankomatMapiranja : SubclassMap<Bankomat>
    {
        public BankomatMapiranja()
        {
            Table("Bankomat");
            KeyColumn("UredjajID");
            Map(x => x.MaxIznos).Column("MaxIznos");
            HasMany(x => x.brojNovcanica)
                .KeyColumn("UredjajID")
                .Inverse()
                .Cascade.AllDeleteOrphan();
        }
    }
}
