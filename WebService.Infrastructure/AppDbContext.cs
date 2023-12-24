using Microsoft.EntityFrameworkCore;
using System.Reflection;
using WebService.Domain;

namespace WebService.Infrastructure;

/// <summary>
/// Контекст базы данных.
/// </summary>
public class AppDbContext : DbContext
{

    public DbSet<CalculationMeter> CalculationMeters { get; set; } = null!;

    public DbSet<CalculationMeterByPeriod> CalculationMeterByPeriods { get; set; } = null!;

    public DbSet<ConsumptionObject> ConsumptionObjects { get; set; } = null!;

    public DbSet<CurrentTransformer> CurrentTransformers { get; set; } = null!;

    public DbSet<MeasurementPoint> MeasurementPoints { get; set; } = null!;

    public DbSet<Meter> Meters { get; set; } = null!;

    public DbSet<Organization> Organizations { get; set; } = null!;

    public DbSet<Period> Periods { get; set; } = null!;

    public DbSet<SubsidiaryOrganization> SubsidiaryOrganizations { get; set; } = null!;

    public DbSet<SupplyPoint> SupplyPoints { get; set; } = null!;

    public DbSet<VoltageTransformer> VoltageTransformers { get; set; } = null!;

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }
}
