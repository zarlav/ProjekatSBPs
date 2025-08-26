using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using ProjekatSBP.Entiteti;
namespace ProjekatSBP.Mapiranja
{
    public class UredjajMapiranja : ClassMap<Uredjaj>
    {
        public UredjajMapiranja()
        {
            Table("Uredjaj");
            Id(x => x.Id, "UredjajID").GeneratedBy.TriggerIdentity();
            Map(x => x.Adresa, "Adresa");
            Map(x => x.Proizvodjac, "Proizvodjac");
            Map(x => x.Komentar, "Komentar");
            Map(x => x.Status, "StatusRada")
            .CustomType<NHibernate.Type.EnumStringType<Entiteti.StatusRada>>();
            Map(x => x.DatumInstalacije, "DatumInstalacije");
            Map(x => x.DatumServisa, "DatumServisa");
            Map(x => x.GeogrSirina, "GeogrSirina");
            Map(x => x.GeogrDuzina, "GeogrDuzina");
            References(x => x.PripadaBanci).Column("BankaID").LazyLoad();
            HasManyToMany(x => x.Filijale)
                .Table("Pokriva")
                .ParentKeyColumn("UredjajID")
                .ChildKeyColumn("FilijalaID")
                .Cascade.All();
        }
    }
}
