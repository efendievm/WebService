using WebService.Contracts;
using WebService.Domain;

namespace WebService.Infrastructure.Repositories;

/// <summary>
/// Репозиторий для <see cref="VoltageTransformer"/>.
/// </summary>
public class VoltageTransformerRepository : BaseRepository<VoltageTransformer, AppDbContext>, IRepository<VoltageTransformer>
{
    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="context">Контекст БД.</param>
    public VoltageTransformerRepository(AppDbContext context) : base(context)
    {
    }
}
