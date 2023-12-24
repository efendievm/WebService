namespace WebService.Contracts.Dtos;

/// <summary>
/// ДТО для создания точки измерения электроэнергии.
/// </summary>
public class MeasurementPointCreateDto
{
    /// <summary>
    /// Наименование.
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// Id объекта электропотребления.
    /// </summary>
    public int ConsumptionObjectId { get; set; }

    /// <summary>
    /// Id счетчика электрической энергии.
    /// </summary>
    public int MeterId { get; set; }

    /// <summary>
    /// Id трансформатора тока.
    /// </summary>
    public int CurrentTransformerId { get; set; }

    /// <summary>
    /// Id трансформатора напряжения.
    /// </summary>
    public int VoltageTransformerId { get; set; }
}
