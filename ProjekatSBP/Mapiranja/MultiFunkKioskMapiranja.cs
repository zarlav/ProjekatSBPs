using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using ProjekatSBP.Entiteti;
namespace ProjekatSBP.Mapiranja
{
    public class MultiFunkKioskMapiranja : SubclassMap<MultiFunkKiosk>
    {
        public MultiFunkKioskMapiranja()
        {
            Table("MultifunkcionalniKiosk");
            KeyColumn("UredjajID");
            Map(x => x.PrisustvoSkenera).Column("PrisustvoSkenera ").LazyLoad();
            Map(x => x.PrisustvoStampaca).Column("PrisustvoStampaca").LazyLoad();
            HasManyToMany(x => x.PodrzaniServis)
                .Table("PodrzavaServis")
                .ParentKeyColumn("UredjajID")
                .ChildKeyColumn("ServisID ")
                .Cascade.All()
                .Inverse();
        }
    }
}
