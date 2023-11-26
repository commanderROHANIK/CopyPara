using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopyPara.Domain.Rooms
{
    public enum RoomType
    {
        Coeducated,
        Male,
        Female
    }

    public static class RoomTypeExtension
    {
        public static string RoomTypeToString(this RoomType roomType)
        {
            switch (roomType) 
            {
                case RoomType.Male:
                    return "Male";
                case RoomType.Female:
                    return "Female";
                default:
                    return "";
            }
        }
    }
}
