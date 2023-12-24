namespace WebService.Contracts.Dtos;

/// <summary>
/// ДТО для чтения данных по счётчику электроэнергии.
/// </summary>
public class MeterReadRichDto
{
    /// <summary>
    /// Id счётчика.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Номер.
    /// </summary>
    public int Number { get; set; }

    /// <summary>
    /// Тип счётчика.
    /// </summary>
    public string MeterType { get; set; } = null!;

    /// <summary>
    /// Дата поверки.
    /// </summary>
    public DateTime VerificationDate { get; set; }

    /// <summary>
    /// Id точки измерения.
    /// </summary>
    public int MeasurementPointId { get; set; }

    /// <summary>
    /// Наименование точки измерения.
    /// </summary>
    public string MeasurementPointName { get; set; } = null!;

    /// <summary>
    /// Id объекта потребления.
    /// </summary>
    public int ConsumptionObjectId { get; set; }

    /// <summary>
    /// Наименование объекта потребления.
    /// </summary>
    public string ConsumptionObjectName { get; set; } = null!;
}
