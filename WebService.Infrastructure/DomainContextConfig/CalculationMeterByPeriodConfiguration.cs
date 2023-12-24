using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebService.Domain;

namespace WebService.Infrastructure.DomainContextConfig;

/// <summary>
/// Конфигурация модели <see cref="CalculationMeterByPeriod".
/// </summary>
public class CalculationMeterByPeriodConfiguration : BaseConfiguration<CalculationMeterByPeriod>
{
    public override void Configure(EntityTypeBuilder<CalculationMeterByPeriod> builder)
    {
        base.Configure(builder);

        builder
            .HasOne(q => q.Period)
            .WithMany(q => q.CalculationMeterByPeriods)
            .HasForeignKey(q => q.PeriodId);

        builder
            .HasOne(q => q.MeasurementPoint)
            .WithMany(q => q.CalculationMeterByPeriods)
            .HasForeignKey(q => q.MeasurementPointId);

        builder
            .HasOne(q => q.CalculationMeter)
            .WithMany(q => q.CalculationMeterByPeriods)
            .HasForeignKey(q => q.CalculationMeterId);

        builder.HasIndex(q => new { q.PeriodId, q.MeasurementPointId }).IsUnique();
        builder.HasIndex(q => new { q.PeriodId, q.CalculationMeterId }).IsUnique();
    }
}