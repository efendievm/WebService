using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebService.Domain;

namespace WebService.Infrastructure.DomainContextConfig;

/// <summary>
/// Конфигурация модели <see cref="Period".
/// </summary>
public class PeriodConfiguration : BaseConfiguration<Period>
{
    public override void Configure(EntityTypeBuilder<Period> builder)
    {
        base.Configure(builder);

        builder
            .Property(q => q.Start)
            .HasConversion(v => v.ToUniversalTime(), v => v.ToLocalTime());

        builder
            .Property(q => q.End)
            .HasConversion(v => v.ToUniversalTime(), v => v.ToLocalTime());
    }
}