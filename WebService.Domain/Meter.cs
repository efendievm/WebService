namespace WebService.Domain;

/// <summary>
/// Счетчик электрической энергии.
/// </summary>
public class Meter : BaseEntity
{
    /// <summary>
    /// Номер.
    /// </summary>
    public int Number { get; set; }

    /// <summary>
    /// Тип счётчика.
    /// </summary>
    public MeterType MeterType { get; set; }

    /// <summary>
    /// Дата поверки.
    /// </summary>
    public DateTime VerificationDate { get; set; }

    #region Навигационные поля
    /// <summary>
    /// Точка измерения электроэнергии.
    /// </summary>
    public MeasurementPoint MeasurementPoint { get; set; } = null!;
    #endregion
}
