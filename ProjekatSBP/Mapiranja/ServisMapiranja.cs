using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjekatSBP.Entiteti;
using FluentNHibernate.Mapping;
namespace ProjekatSBP.Mapiranja
{
    public class ServisMapiranja : ClassMap<Servis>
    {
        public ServisMapiranja()
        {
            Table("Servis");
            Id(x => x.ServisID).Column("ServisID").GeneratedBy.Sequence("SERVIS_SEQ");
            Map(x => x.Naziv).Column("Naziv").LazyLoad();
            HasManyToMany(x => x.MultiKiosci)
                .Table("PodrzavaServis")
                .ParentKeyColumn("ServisID")
                .ChildKeyColumn("UredjajID")
                .Cascade.None();
        }
    }
}
