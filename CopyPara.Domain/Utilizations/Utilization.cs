using CopyPara.Domain.Machines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopyPara.Domain.Utilizations
{
    public class Utilization
    {
        public ulong Id {  get; set; }
        public DateOnly Date {  get; set; }
        public ulong MachineId { get; set; }
        public Machine Machine { get; set; }
        public int CurrentUtilization { get; set; }
    }
}
