using CopyPara.Application.Machine;
using CopyPara.Application.Patient;
using CopyPara.Application.Utilization;
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
        private readonly IUtilizationRepository _utilizationRepository;
        private readonly IMachineRepository _machineRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAuthDoctor _auth;

        public CreateTreatmentHandler(ITreatmentRepository treatmentRepository,
                                      IPatientRepository patientRepository,
                                      IUtilizationRepository utilizationRepository,
                                      IMachineRepository machineRepository,
                                      IUnitOfWork unitOfWork,
                                      IAuthDoctor auth)
        {
            _treatmentRepository = treatmentRepository;
            _patientRepository = patientRepository;
            _utilizationRepository = utilizationRepository;
            _machineRepository = machineRepository;
            _unitOfWork = unitOfWork;
            _auth = auth;
        }

        public async Task<string> Handle(CreateTreatmentRequest request, CancellationToken cancellationToken)
        {
            var doctor = await _auth.GetAuthenticatedDoctorAsync(cancellationToken);

            var patient = await _patientRepository.GetPatientAsync(request.PatientId, cancellationToken);
            var cancer = await _treatmentRepository.GetCancerAsync(request.CancerId, cancellationToken);

            if (doctor == null || patient == null || cancer == null)
                return "failure";

            Domain.Treatments.Treatment treatment = new()
            {
                DoctorId = doctor.Id,
                Doctor = doctor,
                PatientId = request.PatientId,
                Patient = patient,
                CancerId = request.CancerId,
                Cancer = cancer,
                StartDate = request.StartDate,
                Fraction = request.Fraction,
                Weight = request.Weight
            };

            await _treatmentRepository.AddAsync(treatment, cancellationToken);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return "success";
        }
    }
}
