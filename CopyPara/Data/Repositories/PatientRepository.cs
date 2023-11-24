using CopyPara.Application.Patient;
using CopyPara.Domain.Patients;

namespace CopyPara.Data.Repositories;

public sealed class PatientRepository : IPatientRepository
{
    private readonly ApplicationDbContext _context;

    public PatientRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Patient patient, CancellationToken cancellationToken = default)
    {
        await _context.Patients.AddAsync(patient, cancellationToken);
    }
}
