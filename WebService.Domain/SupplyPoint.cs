namespace WebService.Domain;

/// <summary>
/// Точка поставки электроэнергии.
/// </summary>
public class SupplyPoint : BaseEntity
{
    /// <summary>
    /// Наименование.
    /// </summary>
    public string Name { get; set; } = null!;

    #region Навигационные поля
    /// <summary>
    /// Id объекта электропотребления.
    /// </summary>
    public int ConsumptionObjectId { get; set; }

    /// <summary>
    /// Объект электропотребления.
    /// </summary>
    public ConsumptionObject ConsumptionObject { get; set; } = null!;
    #endregion
}
