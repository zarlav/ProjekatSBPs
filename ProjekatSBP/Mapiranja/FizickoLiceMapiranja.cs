using FluentNHibernate.Mapping;
using ProjekatSBP.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatSBP.Mapiranja
{
    public class FizickoLiceMapiranja : SubclassMap<FizickoLice>
    {
        public FizickoLiceMapiranja()
        {
            Table("FizickoLice");
            KeyColumn("KlijentId");

            Map(x => x.prezime).Column("PREZIME");
            Map(x => x.licnoIme).Column("LICNOIME");
            Map(x => x.imeRoditelja).Column("IMERODITELJA");
            Map(x => x.jmbg).Column("JMBG");
            Map(x => x.brLicneKarte).Column("BROJLK");
            Map(x => x.datumRodj).Column("DATUMRODJENJA");
            Map(x => x.mestoIzdavanja).Column("MESTOIZDAVANJA");
            Map(x => x.adresa).Column("ADRESA");
            HasMany(x => x.Telefoni)
                .Table("KontaktFizLice")
                .KeyColumn("KlijentID")
                .Element("Telefon")
                .LazyLoad();
        }
    }
}
