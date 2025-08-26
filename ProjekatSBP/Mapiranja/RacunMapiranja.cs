using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using ProjekatSBP.Entiteti;
using NHibernate.Mapping;

namespace ProjekatSBP.Mapiranja
{
    public class RacunMapiranja : ClassMap<Racun>
    {
        public RacunMapiranja()
        {
            Table("Racun");

            Id(x => x.RacunId)
                .Column("RacunID")
                .GeneratedBy.Sequence("SERVIS_SEQ");


            References(x => x.Banka)
                .Column("BankaID")
                .Not.Nullable()
                .LazyLoad();

            References(x => x.Klijent)
                .Column("KlijentID")
                .Not.Nullable()
                .LazyLoad();

            Map(x => x.Valuta, "Valuta");
            Map(x => x.DatumOtvaranja, "DatumOtvaranja");
            Map(x => x.Saldo, "Saldo");
            Map(x => x.Status, "Status")
                .CustomType<NHibernate.Type.EnumStringType<Entiteti.StatusRacuna>>();

            HasMany(x => x.Kartice)
                .KeyColumn("RacunID")
                .Inverse()
                .LazyLoad()
                .Cascade.All();
        }
    }
}
