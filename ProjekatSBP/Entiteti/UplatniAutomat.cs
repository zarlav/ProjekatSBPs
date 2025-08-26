using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatSBP.Entiteti
{
    public class UplatniAutomat : Uredjaj
    {
        public virtual bool ValidatorZaPapirniNovac { get; set; }
        public virtual ICollection<VrstaUplate> PodrzaneVrsteUplate { get; set; } = new List<VrstaUplate>();    
    }
}
