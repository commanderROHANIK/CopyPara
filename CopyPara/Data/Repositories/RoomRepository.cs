using CopyPara.Application.Rooms;
using CopyPara.Components.Account.Pages.Manage;
using CopyPara.Domain.Patients;
using CopyPara.Domain.Rooms;
using Microsoft.EntityFrameworkCore;

namespace CopyPara.Data.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly ApplicationDbContext _context;
        
        public RoomRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Room?> GetRoom(Patient patient)
        {
            Task<Room?> room = null;
            if (patient.Condition.IsDisabled())
            {
                room = _context.Rooms.Where(x => x.OccupiedBeds < x.NumberOfBeds)
                    .OrderByDescending(x => x.WithBath)
                    .ThenByDescending(x => x.NumberOfBeds)
                    .FirstOrDefaultAsync();

                return await room;
            }

            room = _context.Rooms.Where(x => x.OccupiedBeds < x.NumberOfBeds)
                    .OrderBy(x => x.WithBath)
                    .ThenByDescending(x => x.NumberOfBeds)
                    .FirstOrDefaultAsync();

            var resultPatient = new Patient()
            {
                Id = patient.Id,
                Condition = patient.Condition,
                Gender = patient.Gender,
                Name = patient.Name,
                Room = room.Result,
                RoomId = room.Result.Id
            };

            _context.Patients.Update(resultPatient);

            await _context.SaveChangesAsync();

            return await room;
        }

        public void Update(Room room)
        {
            _context.Update(room);
        }
    }
}
