using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using CopyPara.Domain.Treatments;

namespace CopyPara.Domain.Occasions
{
    public class Occasion
    {
        public ulong Id { get; set; }
        public DateTime Date { get; set; }

        public ulong TreatmentId { get; set; }
        public Treatment Treatment { get; set; }

        public ulong MachineId { get; set; }
        public Machine Machine { get; set; }
    }
}
