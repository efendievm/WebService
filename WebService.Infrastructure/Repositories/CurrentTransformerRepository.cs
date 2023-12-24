using WebService.Contracts;
using WebService.Domain;

namespace WebService.Infrastructure.Repositories;

/// <summary>
/// Репозиторий для <see cref="CurrentTransformer"/>.
/// </summary>
public class CurrentTransformerRepository : BaseRepository<CurrentTransformer, AppDbContext>, IRepository<CurrentTransformer>
{
    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="context">Контекст БД.</param>
    public CurrentTransformerRepository(AppDbContext context) : base(context)
    {
    }
}
