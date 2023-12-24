using WebService.Contracts;
using WebService.Domain;

namespace WebService.Infrastructure.Repositories;

/// <summary>
/// Репозиторий для <see cref="Meter"/>.
/// </summary>
public class MeterRepository : BaseRepository<Meter, AppDbContext>, IRepository<Meter>
{
    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="context">Контекст БД.</param>
    public MeterRepository(AppDbContext context) : base(context)
    {
    }
}
