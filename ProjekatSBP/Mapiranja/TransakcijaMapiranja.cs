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
    public class TransakcijaMapiranja : ClassMap<Transakcija>
    {
        public TransakcijaMapiranja()
        {
            Table("Transakcija");
            Id(x => x.TransakcijaId).Column("TransakcijaID").GeneratedBy.Sequence("SERVIS_SEQ");

            Map(x => x.Iznos, "Iznos");
            Map(x => x.Valuta, "Valuta");
            Map(x => x.RazlogNeuspeha, "RazlogNeuspeha");
            Map(x => x.DatumVreme, "DatumVreme");
            Map(x => x.Status, "Status");
            Map(x => x.Vrsta, "Vrsta")
            .CustomType<NHibernate.Type.EnumStringType<Entiteti.VrstaTransakcije>>();
            References(x => x.Kartica)
                .Column("KarticaID")
                .Cascade.None();

            References(x => x.Uredjaj)
                .Column("UredjajID")
                .Cascade.None();
        }
    }
}
