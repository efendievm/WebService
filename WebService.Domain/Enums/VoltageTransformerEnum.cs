using System.ComponentModel;

namespace WebService.Domain;

/// <summary>
/// Тип трансформатора напряжения.
/// </summary>
public enum VoltageTransformerType
{
    [Description("Заземляемый")]
    Grounded = 0,
    [Description("Незаземляемый")]
    Ungrounded = 1,
    [Description("Каскадный")]
    Cascade = 2,
    [Description("Емкостный")]
    Capacitive = 3,
    [Description("Двухобмоточный")]
    DoubleWinding = 4,
    [Description("Трёхобмоточный")]
    ThreeWinding = 5,
    [Description("Оптико-электронный")]
    Optoelectronic = 6
}
