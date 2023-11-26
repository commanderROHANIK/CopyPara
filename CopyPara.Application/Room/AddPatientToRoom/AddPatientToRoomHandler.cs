using CopyPara.Application.Patient;
using CopyPara.Application.Rooms;
using MediatR;
using System.Reflection.Metadata.Ecma335;

namespace CopyPara.Application.Room.AddPatientToRoom
{
    public sealed class AddPatientToRoomHandler : IRequestHandler<AddPatientToRoomRequest, string>
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IPatientRepository _patientRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AddPatientToRoomHandler(IRoomRepository roomRepository, IPatientRepository patientRepository, IUnitOfWork unitOfWork)
        {
            _roomRepository = roomRepository;
            _patientRepository = patientRepository;
            _unitOfWork = unitOfWork;
        }

        async Task<string> IRequestHandler<AddPatientToRoomRequest, string>.Handle(AddPatientToRoomRequest request, CancellationToken cancellationToken)
        {
            var patient = await _patientRepository.GetPatientAsync(request.PatientId);

            if (patient == null)
            {
                return "bad";
            }

            var room = await _roomRepository.GetSuitableRoom(patient);

            if (room == null)
            {
                return "morebad";
            }

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return "asd";
        }
    }
}
