using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatSBP.Entiteti
{
    public class Kartica
    {
        public virtual int KarticaId { get; set; }
        public virtual decimal DnevniLimit { get; set; }
        public virtual string BrojKartice { get; set; }
        public virtual DateTime DatumIzdavanja { get; set; }
        public virtual DateTime DatumIsteka { get; set; }
        public virtual Racun Racun { get; set; }          
        public virtual IList<Transakcija> Transakcije { get; set; } = new List<Transakcija>();

        public Kartica()
        {
            Transakcije = new List<Transakcija>();
        }
    }
}
