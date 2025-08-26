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
    public class BankaMapiranja : ClassMap<Banka>
    {
        public BankaMapiranja()
        {
            Table("Banka");
            Id(x => x.Id, "BankaID ").GeneratedBy.TriggerIdentity();
            Map(x => x.Naziv, "Naziv");
            Map(x => x.Adresa, "Adresa");
            Map(x => x.WebAdresa, "WebAdresa");
            HasMany(x => x.Uredjaji).KeyColumn("BankaID").LazyLoad();
            HasMany(x => x.Telefoni)
                .Table("TelefonBanka")
                .KeyColumn("BankaID")
                .Element("Telefon")
                .LazyLoad()
                .Cascade.All();
            HasMany(x => x.EmailAdrese)
                .Table("EmailBanka")
                .KeyColumn("BankaID")
                .Element("Email")
                .LazyLoad()
                .Cascade.All();
        }
    }
}
