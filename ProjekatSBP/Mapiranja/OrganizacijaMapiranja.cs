using FluentNHibernate.Mapping;
using ProjekatSBP.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatSBP.Mapiranja
{
    public class OrganizacijaMapiranja : SubclassMap<Organizacija>
    {
        public OrganizacijaMapiranja()
        {
            Table("Organizacija");
            KeyColumn("KlijentId");

            Map(x => x.registar, "Registar");
            Map(x => x.osnivac, "Osnivac");
            Map(x => x.adresa, "Adresa");
            Map(x => x.tipOrganizacije, "TipOrganizacije");
            HasMany(x => x.Telefoni)
                .Table("KontaktTelefonOrganizacija")
                .KeyColumn("KlijentId")
                .Element("Telefon")
                .LazyLoad()
                .Cascade.All();
            HasMany(x => x.EmailAdrese)
                .Table("KontaktEmailOrganizacija")
                .KeyColumn("KlijentId")
                .Element("Email")
                .LazyLoad()
                .Cascade.All();
        }
    }
}
