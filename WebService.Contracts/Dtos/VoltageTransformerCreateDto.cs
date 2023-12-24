using WebService.Domain;

namespace WebService.Contracts.Dtos;

/// <summary>
/// ДТО для создания трансформатора напряжения.
/// </summary>
public class VoltageTransformerCreateDto
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
}
