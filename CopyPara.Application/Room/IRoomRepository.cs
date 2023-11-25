using CopyPara.Domain.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopyPara.Application.Rooms
{
    public interface IRoomRepository
    {
        Task<Domain.Rooms.Room?> GetRoom(Domain.Patients.Patient patient);
        void Update(Domain.Rooms.Room room);
    }
}
