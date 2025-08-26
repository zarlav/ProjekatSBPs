using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatSBP.Entiteti
{
    public class BrojNovcanicaUBankomat
    {
        public virtual int BrojKomada { get; set; }

        public virtual Uredjaj Uredjaj { get; set; }
        public virtual Apoen Apoen { get; set; }
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            var other = (BrojNovcanicaUBankomat)obj;
            return Equals(Uredjaj?.Id, other.Uredjaj?.Id)
                && Equals(Apoen?.ApoenID, other.Apoen?.ApoenID);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + (Uredjaj?.Id ?? 0).GetHashCode();
                hash = hash * 23 + (Apoen?.ApoenID ?? 0).GetHashCode();
                return hash;
            }
        }
    }
}
