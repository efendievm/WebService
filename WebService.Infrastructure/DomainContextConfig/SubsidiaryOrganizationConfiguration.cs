using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebService.Domain;

namespace WebService.Infrastructure.DomainContextConfig;

/// <summary>
/// Конфигурация модели <see cref="SubsidiaryOrganization".
/// </summary>
public class SubsidiaryOrganizationConfiguration : BaseConfiguration<SubsidiaryOrganization>
{
    public override void Configure(EntityTypeBuilder<SubsidiaryOrganization> builder)
    {
        base.Configure(builder);

        builder
            .HasOne(q => q.Organization)
            .WithMany(q => q.SubsidaryOrganizations)
            .HasForeignKey(q => q.OrganizationId);
    }
}
