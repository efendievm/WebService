using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebService.Domain;

namespace WebService.Infrastructure.DomainContextConfig;

/// <summary>
/// Конфигурация модели <see cref="Meter".
/// </summary>
public class MeterConfiguration : BaseConfiguration<Meter>
{
    public override void Configure(EntityTypeBuilder<Meter> builder)
    {
        base.Configure(builder);

        builder
            .Property(e => e.MeterType)
            .HasConversion(v => (int)v, v => (MeterType)v);

        builder
            .HasOne(q => q.MeasurementPoint)
            .WithOne(q => q.Meter)
            .HasForeignKey<MeasurementPoint>(q => q.MeterId);
    }
}
