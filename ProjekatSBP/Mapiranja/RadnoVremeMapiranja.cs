using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjekatSBP.Entiteti;
namespace ProjekatSBP.Mapiranja
{
    public class RadnoVremeMapiranja : ClassMap<RadnoVreme>
    {
        public RadnoVremeMapiranja()
        {
            Table("RadnoVreme");

            CompositeId(x => x.Id)
                .KeyReference(x => x.Filijala, "FilijalaID")
                .KeyProperty(x => x.Dan, "Dan");

            Map(x => x.PocetnoVreme).Column("PocetnoVreme");
            Map(x => x.ZavrsnoVreme).Column("KrajnjeVreme");

        }
    }
}
