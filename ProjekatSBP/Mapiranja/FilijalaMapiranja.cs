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
    public class FilijalaMapiranja : ClassMap<Filijala>
    {
        public FilijalaMapiranja()
        {
            Table("Filijala");
            Id(x => x.Id).Column("FilijalaID").GeneratedBy.Identity();
            Map(x => x.RedniBrUBanci).Column("REDNIBROJUBANCI");
            Map(x => x.Adresa).Column("Adresa");
            HasManyToMany(x => x.Uredjaji)
                .Table("Pokriva")
                .ParentKeyColumn("FilijalaID")
                .ChildKeyColumn("UredjajID")
                .Cascade.AllDeleteOrphan();
            HasMany(x => x.Telefoni)
                .Table("KontaktFilijala")
                .KeyColumn("FilijalaID")
                .Element("Telefon")
                .LazyLoad()
                .Cascade.AllDeleteOrphan();
            References(x => x.SastojiSeOd).Column("BankaID").LazyLoad().Cascade.None();
            HasMany(x => x.RadnaVremena)
                .KeyColumn("FilijalaID")
                .Cascade.All()        // automatski save/update/delete
                .Inverse()            // RadnoVreme ima referencu na Filijala
                .LazyLoad();
        }
    }
}
