namespace WebService.Domain;

/// <summary>
/// Связь между ТИ и расчётным прибором учёта по интервалу времени.
/// </summary>
public class CalculationMeterByPeriod : BaseEntity
{
    /// <summary>
    /// Id периода учёта.
    /// </summary>
    public int PeriodId { get; set; }

    /// <summary>
    /// Период учёта.
    /// </summary>
    public Period Period { get; set; } = null!;

    /// <summary>
    /// Id точки измерения.
    /// </summary>
    public int MeasurementPointId { get; set; }

    /// <summary>
    /// Точка измерения.
    /// </summary>
    public MeasurementPoint MeasurementPoint { get; set; } = null!;

    /// <summary>
    /// Id прибора учёта.
    /// </summary>
    public int CalculationMeterId { get; set; }

    /// <summary>
    /// Прибор учёта.
    /// </summary>
    public CalculationMeter CalculationMeter { get; set; } = null!;
}
