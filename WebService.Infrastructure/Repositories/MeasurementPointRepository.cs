using WebService.Contracts;
using WebService.Domain;

namespace WebService.Infrastructure.Repositories;

/// <summary>
/// Репозиторий для <see cref="MeasurementPoint"/>.
/// </summary>
public class MeasurementPointRepository : BaseRepository<MeasurementPoint, AppDbContext>, IRepository<MeasurementPoint>
{
    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="context">Контекст БД.</param>
    public MeasurementPointRepository(AppDbContext context) : base(context)
    {
    }
}
