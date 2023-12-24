namespace WebService.Domain;

/// <summary>
/// Трансформатор напряжения.
/// </summary>
public class VoltageTransformer : BaseEntity
{
    /// <summary>
    /// Номер.
    /// </summary>
    public int Number { get; set; }

    /// <summary>
    /// Тип трансформатора напряжения.
    /// </summary>
    public VoltageTransformerType TransformerType { get; set; }

    /// <summary>
    /// Дата поверки.
    /// </summary>
    public DateTime VerificationDate { get; set; }

    /// <summary>
    /// Коэффициент трансформации напряжения.
    /// </summary>
    public int TransformationRatio { get; set; }

    #region Навигационные поля
    /// <summary>
    /// Точка измерения электроэнергии.
    /// </summary>
    public MeasurementPoint MeasurementPoint { get; set; } = null!;
    #endregion
}
