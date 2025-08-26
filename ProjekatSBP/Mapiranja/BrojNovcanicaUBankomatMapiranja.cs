using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjekatSBP.Entiteti;
namespace ProjekatSBP.Mapiranja
{
    public class BrojNovcanicaUBankomatMapiranja : ClassMap<BrojNovcanicaUBankomat>
    {
        public BrojNovcanicaUBankomatMapiranja()
        {
            Table("BrNovcanicaUBankomat");

            CompositeId()
                .KeyReference(x => x.Uredjaj, "UredjajID")
                .KeyReference(x => x.Apoen, "ApoenID");

            Map(x => x.BrojKomada)
                .Column("BrojKomada")
                .Not.Nullable()
                .Default("0");
        }
    }
}
