using FluentNHibernate.Mapping;
using ProjekatSBP.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatSBP.Mapiranja
{
    public class PravnoLiceMapiranja : SubclassMap<PravnoLice>
    {
        public PravnoLiceMapiranja()
        {
            Table("PravnoLice");
            KeyColumn("KlijentId");
            Map(x => x.pib, "PIB");
            Map(x => x.maticniBr, "MaticniBroj");
            Map(x => x.delatnost, "Delatnost");
            Map(x => x.kontaktOsoba, "KontaktOsoba");
            Map(x => x.firma, "Firma");
            Map(x => x.adresa, "Adresa");
            HasMany(x => x.Telefoni)
               .Table("KontaktTelefonPravLice")
               .KeyColumn("KlijentId")
               .Element("Telefon")
               .LazyLoad()
               .Cascade.All();
            HasMany(x => x.EmailAdrese)
               .Table("KontaktEmailPravLice")
               .KeyColumn("KlijentId")
               .Element("Email")
               .LazyLoad()
               .Cascade.All();
        }
    }
}
