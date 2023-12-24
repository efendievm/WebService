namespace WebService.Domain;

/// <summary>
/// Точка измерения электроэнергии.
/// </summary>
public class MeasurementPoint : BaseEntity
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

    /// <summary>
    /// Id счетчика электрической энергии.
    /// </summary>
    public int MeterId { get; set; }


    /// <summary>
    /// Счетчик электрической энергии.
    /// </summary>
    public Meter Meter { get; set; } = null!;

    /// <summary>
    /// Id трансформатора тока.
    /// </summary>
    public int CurrentTransformerId { get; set; }

    /// <summary>
    /// Трансорматор тока.
    /// </summary>
    public CurrentTransformer CurrentTransformer { get; set; } = null!;


    /// <summary>
    /// Id трансформатора напряжения.
    /// </summary>
    public int VoltageTransformerId { get; set; }

    /// <summary>
    /// Трансорматор напряжения.
    /// </summary>
    public VoltageTransformer VoltageTransformer { get; set; } = null!;

    /// <summary>
    /// Расчетные приборы учета по периодам.
    /// </summary>
    public List<CalculationMeterByPeriod> CalculationMeterByPeriods { get; set; } = null!;
    #endregion
}
