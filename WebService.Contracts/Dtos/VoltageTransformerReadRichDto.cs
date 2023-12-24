namespace WebService.Contracts.Dtos;

/// <summary>
/// ДТО для чтения данных по трансформатору напряжения.
/// </summary>
public class VoltageTransformerReadRichDto
{
    /// <summary>
    /// Id трансформатора напряжения.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Номер.
    /// </summary>
    public int Number { get; set; }

    /// <summary>
    /// Тип трансформатора напряжения.
    /// </summary>
    public string TransformerType { get; set; } = null!;

    /// <summary>
    /// Дата поверки.
    /// </summary>
    public DateTime VerificationDate { get; set; }

    /// <summary>
    /// Коэффициент трансформации напряжения.
    /// </summary>
    public int TransformationRatio { get; set; }

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
