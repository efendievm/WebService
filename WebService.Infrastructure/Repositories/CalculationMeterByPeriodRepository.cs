using WebService.Contracts;
using WebService.Domain;

namespace WebService.Infrastructure.Repositories;

/// <summary>
/// Репозиторий для <see cref="CalculationMeterByPeriod"/>.
/// </summary>
public class CalculationMeterByPeriodRepository : BaseRepository<CalculationMeterByPeriod, AppDbContext>, IRepository<CalculationMeterByPeriod>
{
    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="context">Контекст БД.</param>
    public CalculationMeterByPeriodRepository(AppDbContext context) : base(context)
    {
    }
}
