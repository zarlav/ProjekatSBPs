using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjekatSBP.Entiteti;
using FluentNHibernate.Conventions.Helpers;
namespace ProjekatSBP.Mapiranja
{
    public class VrstaUplateMapiranja : ClassMap<VrstaUplate>
    {
        public VrstaUplateMapiranja()
        {
            Table("VrstaUplate");
            Id(x => x.VrstaUplateID).Column("VrstaUplateID").GeneratedBy.Sequence("VRSTAUPLATE_SEQ");
            Map(x => x.Naziv).Column("Naziv").LazyLoad();
            HasManyToMany(x => x.UplatniAutomati)
                .Table("PodrzavaUplatu")
                .ParentKeyColumn("VrstaUplateID")
                .ChildKeyColumn("UredjajID")
                    .Cascade.None()
                    .Inverse();
        }
    }
}
