using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations.Schema;
using WebService.Domain;

namespace WebService.Infrastructure.DomainContextConfig;

/// <summary>
/// Базовая конфигурация моделей.
/// </summary>
/// <typeparam name="T">Тип модели.</typeparam>
public class BaseConfiguration<T> : IEntityTypeConfiguration<T>
    where T : BaseEntity
{
    public virtual void Configure(EntityTypeBuilder<T> builder)
    {
        builder.HasKey(entity => entity.Id);
    }
}
