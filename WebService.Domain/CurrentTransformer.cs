namespace WebService.Domain;

/// <summary>
/// Трансформатор тока.
/// </summary>
public class CurrentTransformer : BaseEntity
{
    /// <summary>
    /// Номер.
    /// </summary>
    public int Number { get; set; }

    /// <summary>
    /// Тип трансформатора тока.
    /// </summary>
    public CurrentTransformerType TransformerType { get; set; }

    /// <summary>
    /// Дата поверки.
    /// </summary>
    public DateTime VerificationDate { get; set; }

    /// <summary>
    /// Коэффициент трансформации тока.
    /// </summary>
    public int TransformationRatio { get; set; }

    #region Навигационные поля
    /// <summary>
    /// Точка измерения электроэнергии.
    /// </summary>
    public MeasurementPoint MeasurementPoint { get; set; } = null!;
    #endregion
}
