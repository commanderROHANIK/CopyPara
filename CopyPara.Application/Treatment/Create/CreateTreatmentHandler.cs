using CopyPara.Application.Patient;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopyPara.Application.Treatment.Create
{
    public sealed class CreateTreatmentHandler : IRequestHandler<CreateTreatmentRequest, string>
    {
        private readonly ITreatmentRepository _treatmentRepository;
        private readonly IPatientRepository _patientRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateTreatmentHandler(ITreatmentRepository treatmentRepository, IPatientRepository patientRepository, IUnitOfWork unitOfWork)
        {
            _treatmentRepository = treatmentRepository;
            _patientRepository = patientRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<string> Handle(CreateTreatmentRequest request, CancellationToken cancellationToken)
        {
            var patient = await _patientRepository.GetPatientAsync(request.PatientId);
            var cancer = await _treatmentRepository.GetCancerAsync(request.CancerId);

            if (patient == null || cancer == null)
                return "failure";
            
            Domain.Treatments.Treatment treatment = new()
            {
                Id = request.Id,
                PatientId = request.PatientId,
                Patient = patient,
                CancerId = request.CancerId,
                Cancer = cancer,
            };

            await _treatmentRepository.AddAsync(treatment, cancellationToken);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return "success";
        }
    }
}
