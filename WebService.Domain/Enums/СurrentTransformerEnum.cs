using System.ComponentModel;

namespace WebService.Domain;

/// <summary>
/// Тип трансформатора тока.
/// </summary>
public enum CurrentTransformerType
{
    [Description("Обмоточный")]
    Winding = 0,
    [Description("Тороидальный")]
    Toroidal = 1,
    [Description("Стержневой")]
    Core = 2
}
