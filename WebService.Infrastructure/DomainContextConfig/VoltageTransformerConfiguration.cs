using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebService.Domain;

namespace WebService.Infrastructure.DomainContextConfig;

/// <summary>
/// Конфигурация модели <see cref="VoltageTransformer".
/// </summary>
public class VoltageTransformerConfiguration : BaseConfiguration<VoltageTransformer>
{
    public override void Configure(EntityTypeBuilder<VoltageTransformer> builder)
    {
        base.Configure(builder);

        builder
            .Property(e => e.TransformerType)
            .HasConversion(v => (int)v, v => (VoltageTransformerType)v);

        builder
            .HasOne(q => q.MeasurementPoint)
            .WithOne(q => q.VoltageTransformer)
            .HasForeignKey<MeasurementPoint>(q => q.VoltageTransformerId);
    }
}
