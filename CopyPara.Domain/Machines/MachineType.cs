using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopyPara.Domain.Machines
{
    public class MachineType
    {
        public ulong Id { get; set; }
        public AcceleratorType Type { get; set; }
        public List<Features> Features { get; set; } = [];
        public List<Machine> Machines { get; set;} = [];
    }
}
