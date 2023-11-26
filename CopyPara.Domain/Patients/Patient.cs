using CopyPara.Domain.Patients.Enums;
using CopyPara.Domain.Rooms;

namespace CopyPara.Domain.Patients;

public class Patient
{
    public ulong Id { get; set; }

    public ulong? RoomId { get; set; } = null;
    public Room? Room { get; set; } = null;

    public string Name { get; set; } = string.Empty;
    public Sex Sex { get; set; }
    public Condition Condition { get; set; }
}
