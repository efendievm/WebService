using WebService.Domain;

namespace WebService.Contracts.Dtos;

/// <summary>
/// ДТО для добавления счётчика электроэнергии.
/// </summary>
public class MeterCreateDto
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
}
