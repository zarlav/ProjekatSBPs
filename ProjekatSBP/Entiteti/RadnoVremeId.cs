using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatSBP.Entiteti
{
    public class RadnoVremeId
    {
        public virtual Filijala Filijala { get; set; }   
        public virtual string Dan { get; set; }

        public override bool Equals(object obj)
        {
            var other = obj as RadnoVremeId;
            if (other == null) return false;
            return Equals(Filijala?.Id, other.Filijala?.Id) && Dan == other.Dan;
        }

        public override int GetHashCode()
        {
            return (Filijala?.Id ?? 0).GetHashCode() ^ Dan.GetHashCode();
        }
    }
}
