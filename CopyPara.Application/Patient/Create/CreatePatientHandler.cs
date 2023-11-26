using CopyPara.Domain.Patients;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopyPara.Application.Patient.Create;

internal sealed class CreatePatientHandler : IRequestHandler<CreatePatientRequest, ulong>
{
    private readonly IPatientRepository _patientRepository;
    private readonly IUnitOfWork _unitOfWork;
    
    public CreatePatientHandler(IPatientRepository patientRepository, IUnitOfWork unitOfWork)
    {
        _patientRepository = patientRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ulong> Handle(CreatePatientRequest request, CancellationToken cancellationToken)
    {
        Domain.Patients.Patient patient = new()
        {
            Name = request.Name,
            Condition = request.Condition,
            Sex = request.Sex,
        };

        try
        {
            await _patientRepository.AddAsync(patient, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return patient.Id;
        }
        catch
        {
            throw new Exception();
        }

    }
}
