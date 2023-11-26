using CopyPara.Application.Machine;
using CopyPara.Application.Occasion;
using CopyPara.Application.Patient.Read;
using CopyPara.Domain.Occasions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopyPara.Application.Utilization.Read;

public class ReadUtiHandler : IRequestHandler<ReadUtiRequest, List<int>>
{
    private readonly IUtilizationRepository _repository;
    private readonly IMachineRepository _machineRepository;

    public ReadUtiHandler(IUtilizationRepository repository,
        IMachineRepository machineRepository)
    {
        _repository = repository;
        _machineRepository = machineRepository;
    }

    public async Task<List<int>> Handle(ReadUtiRequest request, CancellationToken cancellationToken)
    {
        List<int> result = [];
        var machines = _machineRepository.GetAllMachines(cancellationToken);
        foreach (var machine in machines.Result)
        {
            var tmp = _repository.GetUtilizationSum(request.Start, request.End, machine.Id, cancellationToken);
            result.Add(tmp.Result == null ? 0 : tmp.Result);
        }
        return result;
    }
}