using CopyPara.Application.Patient;
using CopyPara.Domain.Patients;
using Microsoft.EntityFrameworkCore;

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

    public ValueTask<Patient?> GetPatientAsync(ulong patientId, CancellationToken cancellationToken = default)
    {
        return _context.Patients.FindAsync(patientId, cancellationToken);
    }

    public IAsyncEnumerable<Patient> SearchByName(string name)
    {
        var patients = _context.Patients
            .AsNoTracking()
            .Where(x => x.Name.Contains(name))
            .AsAsyncEnumerable();

        return patients;
    }
}
