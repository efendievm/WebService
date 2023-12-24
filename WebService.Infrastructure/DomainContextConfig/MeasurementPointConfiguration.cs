using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebService.Domain;

namespace WebService.Infrastructure.DomainContextConfig;

/// <summary>
/// Конфигурация модели <see cref="MeasurementPoint".
/// </summary>
public class MeasurementPointConfiguration : BaseConfiguration<MeasurementPoint>
{
    public override void Configure(EntityTypeBuilder<MeasurementPoint> builder)
    {
        base.Configure(builder);

        builder
            .HasOne(q => q.ConsumptionObject)
            .WithMany(q => q.MeasurementPoints)
            .HasForeignKey(q => q.ConsumptionObjectId);
    }
}
