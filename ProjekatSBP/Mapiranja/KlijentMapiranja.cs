using FluentNHibernate.Mapping;
using ProjekatSBP.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatSBP.Mapiranja
{
    public class KlijentMapiranja : ClassMap<Klijent>
    {
        public KlijentMapiranja()
        {
            Table("Klijent");
            Id(x => x.id, "KlijentID").GeneratedBy.Native();
            Map(x => x.tip, "Tip");
            HasMany(x => x.racuni)
            .KeyColumn("KlijentId")
            .Inverse()
            .Cascade.All();


        }
    }
}
