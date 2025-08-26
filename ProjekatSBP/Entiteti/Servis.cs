using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatSBP.Entiteti
{
    public class Servis
    {
        public virtual int ServisID { get; protected set; }
        public virtual string Naziv { get; set; }
        public virtual ICollection<MultiFunkKiosk> MultiKiosci { get; set; } = new List<MultiFunkKiosk>();
        public Servis()
        {
            MultiKiosci = new List<MultiFunkKiosk>();
        }
    }
}
