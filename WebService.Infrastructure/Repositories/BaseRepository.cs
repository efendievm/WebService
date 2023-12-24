using Microsoft.EntityFrameworkCore;
using WebService.Contracts;
using WebService.Domain;

namespace WebService.Infrastructure.Repositories;

/// <summary>
/// Базовый репозиторий.
/// </summary>
/// <typeparam name="TModel"></typeparam>
/// <typeparam name="TContext"></typeparam>
public abstract class BaseRepository<TModel, TContext> : IRepository<TModel>
    where TModel : BaseEntity
    where TContext : DbContext
{
    protected readonly TContext Context;
    protected DbSet<TModel> Set => Context.Set<TModel>();

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="context">Контекст БД.</param>
    public BaseRepository(TContext context)
    {
        Context = context;
    }

    /// <summary>
    /// Чтение сущностей.
    /// </summary>
    /// <returns>Запрос на чтение сущностей.</returns>
    public IQueryable<TModel> Get() => Set;

    /// <summary>
    /// Добавление сущности.
    /// </summary>
    /// <param name="model">Добавляемая сущность.</param>
    /// <param name="token">Токен отмены.</param>
    /// <returns>Задача на добавление мущности в БД.</returns>
    public async Task Add(TModel model, CancellationToken token = default)
    {
       await Set.AddAsync(model, token);
       await Context.SaveChangesAsync(token);
    }
}