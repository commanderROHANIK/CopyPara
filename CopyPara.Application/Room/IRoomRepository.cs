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
        Task<Domain.Rooms.Room?> GetSuitableRoom(Domain.Patients.Patient patient);
    }
}
