﻿using CopyPara.Application.Treatment;
using CopyPara.Domain.Cancers;
using CopyPara.Domain.Treatments;
using Microsoft.EntityFrameworkCore;

namespace CopyPara.Data.Repositories;

public sealed class TreatmentRepository : ITreatmentRepository
{
    private readonly ApplicationDbContext _context;

    public TreatmentRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Treatment treatment, CancellationToken cancellationToken = default)
    {
        await _context.Treatments.AddAsync(treatment, cancellationToken);
    }

    public ValueTask<Cancer?> GetCancerAsync(ulong cancerId, CancellationToken cancellationToken = default)
    {
        return _context.Cancers.FindAsync(cancerId, cancellationToken);
    }

    public ValueTask<Treatment?> GetTreatmentAsync(ulong treatmentId, CancellationToken cancellationToken = default)
    {
        return _context.Treatments.FindAsync(treatmentId, cancellationToken);
    }

    Task<Application.Treatment.GetCancer.Cancer[]> ITreatmentRepository.GetCancersForSelectAsync(CancellationToken cancellationToken)
    {
         return _context.Cancers
            .Select(x => new Application.Treatment.GetCancer.Cancer(x.Id, x.CancerType.ToFastString(), x.GetFractions(), x.AvgTimeMins))
            .ToArrayAsync(cancellationToken);
    }
}
