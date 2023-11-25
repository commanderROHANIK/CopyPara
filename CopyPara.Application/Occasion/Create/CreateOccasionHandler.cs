using CopyPara.Application.Machine;
using CopyPara.Application.Patient.Create;
using CopyPara.Application.Treatment;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopyPara.Application.Occasion.Create
{
    internal sealed class CreateOccasionHandler : IRequestHandler<CreateOccasionRequest, string>
    {
        private readonly IOccasionRepository _occasionRepository;
        private readonly ITreatmentRepository _treatmentRepository;
        private readonly IMachineRepository _machineRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateOccasionHandler(IOccasionRepository occasionRepository,
                                     ITreatmentRepository treatmentRepository,
                                     IMachineRepository machineRepository,
                                     IUnitOfWork unitOfWork)
        {
            _machineRepository = machineRepository;
            _occasionRepository = occasionRepository;
            _treatmentRepository = treatmentRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<string> Handle(CreateOccasionRequest request, CancellationToken cancellationToken)
        {
            var machine = await _machineRepository.GetMachineAsync(request.MachineId);
            var treatment = await _treatmentRepository.GetTreatmentAsync(request.TreatmentId);

            if (machine == null || treatment == null)
                return "failure";

            Domain.Occasions.Occasion occasion = new()
            {
                Id = request.Id,
                Date = request.Date,
                Machine = machine,
                MachineId = request.MachineId,
                Treatment = treatment,
                TreatmentId = request.TreatmentId,
            };

            await _occasionRepository.AddAsync(occasion);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return "success";
        }
    }
}
