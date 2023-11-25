using CopyPara.Application;
using CopyPara.Domain.Cancers;
using CopyPara.Domain.Doctors;
using CopyPara.Domain.Machines;
using CopyPara.Domain.Occasions;
using CopyPara.Domain.Patients;
using CopyPara.Domain.Treatments;
using CopyPara.Domain.Utilizations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CopyPara.Data;

public sealed class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options), IUnitOfWork
{
    public DbSet<Patient> Patients => Set<Patient>();

    public DbSet<Doctor> Doctors => Set<Doctor>();

    public DbSet<Machine> Machines => Set<Machine>();

    public DbSet<Occasion> Occasions => Set<Occasion>();

    public DbSet<Treatment> Treatments => Set<Treatment>();

    public DbSet<MachineType> MachineTypes => Set<MachineType>();

    public DbSet<Cancer> Cancers => Set<Cancer>();

    public DbSet<Utilization> Utilization => Set<Utilization>();

    public DbSet<Slot> Slots => Set<Slot>();

    public DbSet<TimeSlot> TimeSlots => Set<TimeSlot>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}
