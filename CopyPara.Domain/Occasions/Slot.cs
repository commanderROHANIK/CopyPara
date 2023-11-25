using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopyPara.Domain.Occasions
{
    public class Slot
    {
        public ulong Id {  get; set; }
        public SlotType Type { get; set; }
        public int Start {  get; set; }
        public int End { get; set; }

    }
}
