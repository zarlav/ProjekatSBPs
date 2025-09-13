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
            Table("Apoen");
            Id(x => x.ApoenID)
                .Column("ApoenID")
                .GeneratedBy.Identity();  
            Map(x => x.tip)
                .Column("Tip")
                .Not.Nullable();
            Map(x => x.Vrednost)
                .Column("Vrednost")
                .Not.Nullable();
            LazyLoad();
        }
    }

}
