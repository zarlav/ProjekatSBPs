using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatSBP.Entiteti
{
    public enum StatusRacuna
    {
        aktivan,
        blokiran,
        ugovoren
    };
    public class Racun
    {
        public virtual int RacunId { get; set; }
        public virtual Banka Banka { get; set; }
        public virtual Klijent Klijent { get; set; }
        public virtual string Valuta { get; set; }
        public virtual DateTime DatumOtvaranja { get; set; }
        public virtual decimal Saldo { get; set; }
        public virtual StatusRacuna Status { get; set; }
        public virtual IList<Kartica> Kartice { get; set; } = new List<Kartica>();

        public Racun()
        {
            Kartice = new List<Kartica>();
        }
    }
}
