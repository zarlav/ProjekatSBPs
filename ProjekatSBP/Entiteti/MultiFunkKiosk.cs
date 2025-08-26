using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatSBP.Entiteti
{
    public class MultiFunkKiosk : Uredjaj
    {
        public virtual bool PrisustvoSkenera { get; set; }
        public virtual bool PrisustvoStampaca { get; set; }
        public virtual ICollection<Servis> PodrzaniServis { get; set; } = new List<Servis>();
    }
}
