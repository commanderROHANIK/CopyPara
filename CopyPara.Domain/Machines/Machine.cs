using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopyPara.Domain.Machines
{
    public class Machine
    {
        public ulong Id { get; set; }
        public string Name { get; set; }
        public ulong MachineTypeId { get; set; }
        public MachineType MachineType { get; set; }

    }
}
