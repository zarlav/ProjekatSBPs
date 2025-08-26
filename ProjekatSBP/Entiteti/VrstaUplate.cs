using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatSBP.Entiteti
{
    public class VrstaUplate
    {
        public virtual int VrstaUplateID { get; set; }
        public virtual string Naziv { get; set; }
        public virtual ICollection<UplatniAutomat> UplatniAutomati { get; set; } = new List<UplatniAutomat>();
        public VrstaUplate()
        {
            UplatniAutomati = new List<UplatniAutomat>();
        }
    }
}
