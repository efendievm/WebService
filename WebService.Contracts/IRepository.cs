using WebService.Domain;

namespace WebService.Contracts;

/// <summary>
/// Репозиторий.
/// </summary>
/// <typeparam name="TModel">Тип сущности.</typeparam>
public interface IRepository<TModel>
    where TModel : BaseEntity
{
    /// <summary>
    /// Чтение сущностей.
    /// </summary>
    /// <returns>Запрос на чтение сущностей.</returns>
    IQueryable<TModel> Get();

    /// <summary>
    /// Добавление сущности.
    /// </summary>
    /// <param name="model">Добавляемая сущность.</param>
    /// <param name="token">Токен отмены.</param>
    /// <returns>Задача на добавление мущности в БД.</returns>
    Task Add(TModel model, CancellationToken token = default);
}