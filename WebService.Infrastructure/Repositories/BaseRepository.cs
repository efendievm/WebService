using Microsoft.EntityFrameworkCore;
using WebService.Contracts;
using WebService.Domain;

namespace WebService.Infrastructure.Repositories;

/// <summary>
/// ������� �����������.
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
    /// �����������.
    /// </summary>
    /// <param name="context">�������� ��.</param>
    public BaseRepository(TContext context)
    {
        Context = context;
    }

    /// <summary>
    /// ������ ���������.
    /// </summary>
    /// <returns>������ �� ������ ���������.</returns>
    public IQueryable<TModel> Get() => Set;

    /// <summary>
    /// ���������� ��������.
    /// </summary>
    /// <param name="model">����������� ��������.</param>
    /// <param name="token">����� ������.</param>
    /// <returns>������ �� ���������� �������� � ��.</returns>
    public async Task Add(TModel model, CancellationToken token = default)
    {
       await Set.AddAsync(model, token);
       await Context.SaveChangesAsync(token);
    }
}
