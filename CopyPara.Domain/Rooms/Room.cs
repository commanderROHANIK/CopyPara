using CopyPara.Domain.Patients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopyPara.Domain.Rooms
{
    public class Room
    {
        public ulong Id { get; set; }
        public int NumberOfBeds { get; set; }
        public int OccupiedBeds { get; set; }
        public bool WithBath { get; set; }
        public RoomType RoomType { get; set; }
        public List<Patient> Patients { get; set; } = [];
    }
}
