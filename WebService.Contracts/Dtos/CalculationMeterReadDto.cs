namespace WebService.Contracts.Dtos;

/// <summary>
/// ДТО для чтения данных по расчётному прибору учёта.
/// </summary>
public class CalculationMeterReadDto
{
    /// <summary>
    /// Id расчётного прибора учёта.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Id точки измерения электроэнергии.
    /// </summary>
    public int MeasurementPointId { get; set; }

    /// <summary>
    /// Наименование точки измерения электроэнергии.
    /// </summary>
    public string MeasurementPointName { get; set; } = null!;

    /// <summary>
    /// Начало периода.
    /// </summary>
    public DateTime Start { get; set; }

    /// <summary>
    /// Конец периода.
    /// </summary>
    public DateTime End { get; set; }
}
