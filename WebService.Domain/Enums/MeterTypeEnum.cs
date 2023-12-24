using System.ComponentModel;

namespace WebService.Domain;

/// <summary>
/// Тип счётчика.
/// </summary>
public enum MeterType
{
    [Description("Индукционный")]
    Induction = 0,
    [Description("Электронный")]
    Electronic = 1
}
