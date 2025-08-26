using FluentNHibernate.Conventions.Helpers;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjekatSBP.Entiteti; 
namespace ProjekatSBP.Mapiranja
{
    public class ApoenMapiranja : ClassMap<Apoen>
    {
        public ApoenMapiranja()
        {
            // Mapiranje klase Apoen na tabelu Apoen
            Table("Apoen");
            Id(x => x.ApoenID).Column("ApoenID").GeneratedBy.Assigned();
            Map(x => x.Vrednost).Column("Vrednost").Not.Nullable().Unique().LazyLoad();

        }
    }
}
