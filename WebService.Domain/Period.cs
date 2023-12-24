namespace WebService.Domain;

/// <summary>
/// Периоды учёта электроэнергии.
/// </summary>
public class Period : BaseEntity
{
    /// <summary>
    /// Начало периода.
    /// </summary>
    public DateTime Start { get; set; }
    
    /// <summary>
    /// Конец периода.
    /// </summary>
    public DateTime End { get; set; }

    #region Навигационные поля
    /// <summary>
    /// Расчетные приборы учета по периодам.
    /// </summary>
    public List<CalculationMeterByPeriod> CalculationMeterByPeriods { get; set; } = null!;
    #endregion
}
