using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebService.Domain;

namespace WebService.Infrastructure.DomainContextConfig;

/// <summary>
/// Конфигурация модели <see cref="SupplyPoint".
/// </summary>
public class SupplyPointConfiguration : BaseConfiguration<SupplyPoint>
{
    public override void Configure(EntityTypeBuilder<SupplyPoint> builder)
    {
        base.Configure(builder);

        builder
            .HasOne(q => q.ConsumptionObject)
            .WithMany(q => q.SupplyPoints)
            .HasForeignKey(q => q.ConsumptionObjectId);
    }
}
