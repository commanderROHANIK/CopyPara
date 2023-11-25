using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace CopyPara.Domain.Occasions
{
    public enum SlotType
    {
        S30,
        S15,
        S12,
        S10
    }

    static class SlotTypeExtensions
    {
        public static int SlotQuantity(this SlotType type)
        {
            switch (type)
            {
                case SlotType.S30: return 2;
                case SlotType.S15: return 4;
                case SlotType.S12: return 5;
                case SlotType.S10: return 6;
                default: throw new ArgumentOutOfRangeException("type");
            }
        }
    }
}
