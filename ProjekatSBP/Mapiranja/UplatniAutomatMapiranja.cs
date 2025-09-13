using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjekatSBP.Entiteti; 
using FluentNHibernate.Mapping;
using FluentNHibernate.Conventions.Helpers;
namespace ProjekatSBP.Mapiranja
{
    public class UplatniAutomatMapiranja : SubclassMap<UplatniAutomat>
    {
        public UplatniAutomatMapiranja()
        {
            Table("UplatniAutomat");
            KeyColumn("UredjajID");
            Map(x => x.ValidatorZaPapirniNovac).Column("ValidatorZaPapirniNovac").LazyLoad();
            HasManyToMany(x => x.PodrzaneVrsteUplate)
                .Table("PodrzavaUplatu")
                .ParentKeyColumn("UredjajID")
                .ChildKeyColumn("VrstaUplateID")
                .Cascade.All();
        }
    }
}
