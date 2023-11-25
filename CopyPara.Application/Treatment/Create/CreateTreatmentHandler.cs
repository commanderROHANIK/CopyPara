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

            //var endDate = request.StartDate.AddDays(request.Fraction);

            //var machineQuery = await _machineRepository.GetAllMachines(cancellationToken);
            //var allMachines = machineQuery.ToList();

            //if (request.Weight > 80 || !request.CanHoldBreath)
            //{
            //    allMachines.RemoveAll(x => x.MachineType.Type == Domain.Machines.AcceleratorType.VitalBeam || x.MachineType.Type == Domain.Machines.AcceleratorType.UniqueClinacOneEnergy);
            //}
            //List<(ulong, int)> utilizations = _utilizationRepository.GetUtilization(request.StartDate, endDate).Result.OrderBy(x => x.Item2).ToList();
            //foreach (var mac in allMachines)
            //{
            //    if (!utilizations.Any(x => x.Item1 == mac.Id))
            //    {
            //        utilizations.Add((mac.Id, 0));
            //    }
            //}

            //var min = 500;
            //var machineType = allMachines.First().MachineType;
            //foreach (var mac in allMachines)
            //{
            //    var utila = utilizations.Where(x => mac.MachineType.Machines.Select(x => x.Id).Contains(x.Item1)).Sum(y => y.Item2);
            //    if(utila < min) {
            //        min = utila;
            //        machineType = mac.MachineType;
            //    }
            //}

                    

            Domain.Treatments.Treatment treatment = new()
            {
                DoctorId = doctor.Id,
                Doctor = doctor,
                PatientId = request.PatientId,
                Patient = patient,
                CancerId = request.CancerId,
                Cancer = cancer,
                StartDate = request.StartDate
            };

            await _treatmentRepository.AddAsync(treatment, cancellationToken);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return "success";
        }
    }
}
