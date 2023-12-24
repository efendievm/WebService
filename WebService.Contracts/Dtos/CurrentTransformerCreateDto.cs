using WebService.Domain;

namespace WebService.Contracts.Dtos;

/// <summary>
/// ДТО для создания трансформатора тока.
/// </summary>
public class CurrentTransformerCreateDto
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
}
