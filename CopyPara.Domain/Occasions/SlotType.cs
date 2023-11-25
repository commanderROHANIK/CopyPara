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

    public static class SlotTypeExtensions
    {
        public static int SlotToQuantity(this SlotType type)
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
        public static SlotType TimeToSlot(int lenght)
        {
            switch (lenght)
            {
                case 30: return SlotType.S30;
                case 15: return SlotType.S15;
                case 12: return SlotType.S12;
                case 10: return SlotType.S10;
                default: throw new ArgumentOutOfRangeException("length");
            }
        }

    }
}
