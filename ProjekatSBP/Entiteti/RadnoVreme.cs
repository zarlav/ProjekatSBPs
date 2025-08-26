using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatSBP.Entiteti
{
    public enum DanUNedelji
    {
        pon, uto, sre, cet, pet, sub, ned
    }
    public class RadnoVreme
    {
        public virtual RadnoVremeId Id { get; set; } = new RadnoVremeId();

        public virtual string PocetnoVreme { get; set; }
        public virtual string ZavrsnoVreme { get; set; }

        public virtual Filijala Filijala
        {
            get => Id.Filijala;
            set => Id.Filijala = value;
        }

        public virtual string Dan
        {
            get => Id.Dan;
            set => Id.Dan = value;
        }

        public virtual DanUNedelji DanEnum
        {
            get => (DanUNedelji)Enum.Parse(typeof(DanUNedelji), Id.Dan);
            set => Id.Dan = value.ToString();
        }
    }

}
