using CopyPara.Application.Occasion;
using CopyPara.Application.Patient.Read;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopyPara.Application.Treatment.Read;
public class ReadTreatmentHandler : IRequestHandler<ReadTreatmentRequest, Domain.Treatments.Treatment[]>
{
    private readonly ITreatmentRepository _repository;

    public ReadTreatmentHandler(ITreatmentRepository repo)
    {
        _repository = repo;
    }

    public Task<Domain.Treatments.Treatment[]> Handle(ReadTreatmentRequest request, CancellationToken cancellationToken)
    {
        var treatment = _repository.GetAllTreatment(cancellationToken).Result;
        return Task.FromResult(treatment);
    }
}