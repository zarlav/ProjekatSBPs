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
    public class DebitnaKarticaMapiranja : SubclassMap<DebitnaKartica>
    {
        public DebitnaKarticaMapiranja()
        {
            Table("DebitnaKartica");
            KeyColumn("KarticaID");   
            Map(x => x.DnevniLimitZaPodizanje, "DnevniLimitZaPodizanje");
        }
    }
}
