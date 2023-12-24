using WebService.Domain;

namespace WebService.Contracts;

/// <summary>
/// �����������.
/// </summary>
/// <typeparam name="TModel">��� ��������.</typeparam>
public interface IRepository<TModel>
    where TModel : BaseEntity
{
    /// <summary>
    /// ������ ���������.
    /// </summary>
    /// <returns>������ �� ������ ���������.</returns>
    IQueryable<TModel> Get();

    /// <summary>
    /// ���������� ��������.
    /// </summary>
    /// <param name="model">����������� ��������.</param>
    /// <param name="token">����� ������.</param>
    /// <returns>������ �� ���������� �������� � ��.</returns>
    Task Add(TModel model, CancellationToken token = default);
}
