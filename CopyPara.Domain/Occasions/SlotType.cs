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
        S10,
        S20,
        Non
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
                case SlotType.S20: return 3;
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
                case 20: return SlotType.S20;
                default: throw new ArgumentOutOfRangeException("length");
            }
        }

        public static int SlotToTime(this SlotType type)
        {
            switch (type)
            {
                case SlotType.S30: return 30;
                case SlotType.S15: return 15;
                case SlotType.S12: return 12;
                case SlotType.S10: return 10;
                case SlotType.S20: return 20;
                default: throw new ArgumentOutOfRangeException("type");
            }
        }

    }
}
