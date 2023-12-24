namespace WebService.Domain;

/// <summary>
/// Базовая сущность.
/// </summary>
public abstract class BaseEntity
{
    /// <summary>
    /// Id сущности.
    /// </summary>
    public int Id { get; set; }
}