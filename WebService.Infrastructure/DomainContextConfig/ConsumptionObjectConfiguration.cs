using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebService.Domain;

namespace WebService.Infrastructure.DomainContextConfig;

/// <summary>
/// Конфигурация модели <see cref="ConsumptionObject"/>.
/// </summary>
public class ConsumptionObjectConfiguration : BaseConfiguration<ConsumptionObject>
{
    public override void Configure(EntityTypeBuilder<ConsumptionObject> builder)
    {
        base.Configure(builder);

        builder
            .HasOne(q => q.SubsidiaryOrganization)
            .WithMany(q => q.ConsumptionObjects)
            .HasForeignKey(q => q.SubsidiaryOrganizationId);
    }
}
