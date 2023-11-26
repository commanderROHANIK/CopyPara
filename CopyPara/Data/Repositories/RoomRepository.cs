using CopyPara.Application.Rooms;
using CopyPara.Components.Account.Pages.Manage;
using CopyPara.Domain.Patients;
using CopyPara.Domain.Patients.Enums;
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

        public async Task<Room?> GetSuitableRoom(Patient patient)
        {
            Room? room = null;
            if (patient.Condition.IsDisabled())
            {
                room = await _context.Rooms.Where(x => x.OccupiedBeds < x.NumberOfBeds)
                             .OrderByDescending(x => x.WithBath)
                             .ThenByDescending(x => x.NumberOfBeds)
                             .FirstOrDefaultAsync();

            }
            else
            {
                room = await _context.Rooms.Where(x => x.OccupiedBeds < x.NumberOfBeds)
                            .OrderBy(x => x.WithBath)
                            .ThenByDescending(x => x.NumberOfBeds)
                            .FirstOrDefaultAsync();
            }


            var resultPatient = await _context.Patients.FindAsync(patient.Id);
            resultPatient.Room = room;
            resultPatient.RoomId = room.Id;

            _context.Update(resultPatient);

            await _context.SaveChangesAsync();

            return room;
        }
    }
}
