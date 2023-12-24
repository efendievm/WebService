namespace WebService.Contracts.Dtos;

/// <summary>
/// ДТО для чтения данных по точке измерения.
/// </summary>
public class MeasurementPointReadDto : MeasurementPointCreateDto
{
    /// <summary>
    /// Id точки измерения.
    /// </summary>
    public int Id { get; set; }
}
