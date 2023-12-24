using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebService.Domain;

namespace WebService.Infrastructure.DomainContextConfig;

/// <summary>
/// Конфигурация модели <see cref="CurrentTransformer".
/// </summary>
public class CurrentTransformerConfiguration : BaseConfiguration<CurrentTransformer>
{
    public override void Configure(EntityTypeBuilder<CurrentTransformer> builder)
    {
        base.Configure(builder);

        builder
            .Property(e => e.TransformerType)
            .HasConversion(v => (int)v, v => (CurrentTransformerType)v);

        builder
            .HasOne(q => q.MeasurementPoint)
            .WithOne(q => q.CurrentTransformer)
            .HasForeignKey<MeasurementPoint>(q => q.CurrentTransformerId);
    }
}
