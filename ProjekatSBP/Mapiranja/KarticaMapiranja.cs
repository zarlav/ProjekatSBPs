using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using NHibernate.Mapping;
using ProjekatSBP.Entiteti;

namespace ProjekatSBP.Mapiranja
{
    public class KarticaMapiranja : ClassMap<Kartica>
    {
        public KarticaMapiranja()
        {
            Table("Kartica");
            Id(x => x.KarticaId).Column("KarticaID").GeneratedBy.Sequence("SERVIS_SEQ");

            Map(x => x.DnevniLimit, "DnevniLimit");
            Map(x => x.BrojKartice, "BrojKartice");
            Map(x => x.DatumIzdavanja, "DatumIzdavanja");
            Map(x => x.DatumIsteka, "DatumIsteka");

            References(x => x.Racun).Column("RacunID").Cascade.None();

            HasMany(x => x.Transakcije)
                .KeyColumn("KarticaID")
                .Inverse()
                .LazyLoad()
                .Cascade.All();

        }
    }
}
