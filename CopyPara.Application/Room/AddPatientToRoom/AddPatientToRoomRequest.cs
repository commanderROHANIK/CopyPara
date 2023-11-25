using MediatR;

namespace CopyPara.Application.Room.AddPatientToRoom
{
    public sealed class AddPatientToRoomRequest : IRequest<string>
    {
        public ulong PatientId { get; set; }
    }
}
