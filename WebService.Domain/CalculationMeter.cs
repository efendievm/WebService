namespace WebService.Domain;

/// <summary>
/// Расчётный прибор учёта.
/// </summary>
public class CalculationMeter : BaseEntity
{
    /// <summary>
    /// Точки измерения по периодам.
    /// </summary>
    public List<CalculationMeterByPeriod> CalculationMeterByPeriods { get; set; } = null!;
}
