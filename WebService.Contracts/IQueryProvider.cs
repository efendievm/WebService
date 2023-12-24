using WebService.Contracts.Dtos;
using WebService.Domain;

namespace WebService.Contracts;

/// <summary>
/// Провайдер запросов.
/// </summary>
public interface IQueryProvider
{
    /// <summary>
    /// Создание точки измерения.
    /// </summary>
    /// <param name="measurementPointCreateDto">ДТО для создания точки измерения.</param>
    /// <returns>Новая точка измерения.</returns>
    Task<MeasurementPoint> CreateMeasurementPoint(MeasurementPointCreateDto measurementPointCreateDto);

    /// <summary>
    /// Создание точки измерения.
    /// </summary>
    /// <param name="meterCreateDto">ДТО для создания счётчика электроэнергии.</param>
    /// <returns>Новый счётчик электроэнергии.</returns>
    Task<Meter> CreateMeter(MeterCreateDto meterCreateDto);

    /// <summary>
    /// Создание трансформатора тока.
    /// </summary>
    /// <param name="meterCreateDto">ДТО для создания трансформатора тока.</param>
    /// <returns>Новый трансформатор тока.</returns>
    Task<CurrentTransformer> CreateCurrentTransformer(CurrentTransformerCreateDto currentTransformerCreateDto);

    /// <summary>
    /// Создание трансформатора тока.
    /// </summary>
    /// <param name="meterCreateDto">ДТО для создания трансформатора напряжения.</param>
    /// <returns>Новый трансформатор напряжения.</returns>
    Task<VoltageTransformer> CreateVoltageTransformer(VoltageTransformerCreateDto voltageTransformerCreateDto);

    /// <summary>
    /// Запрос на получение расчетных приборов учета.
    /// </summary>
    /// <param name="year">Период учёта.</param>
    /// <returns>Запрос на получение расчетных приборов учета.</returns>
    IQueryable<CalculationMeterByPeriod> GetCalculationMeters(int year);

    /// <summary>
    /// Запрос на получение счетчиков с закончившимся сроком поверки.
    /// </summary>
    /// <param name="consumptionObjectId">Id объекта потребления.</param>
    /// <returns>Запрос на получение счетчиков с закончившимся сроком поверки.</returns>
    IQueryable<Meter> GetExpiredMeters(int consumptionObjectId);

    /// <summary>
    /// Запрос на получение трансформаторов тока с закончившимся сроком поверки.
    /// </summary>
    /// <param name="consumptionObjectId">Id объекта потребления.</param>
    /// <returns>Запрос на получение трансформаторов тока с закончившимся сроком поверки.</returns>
    IQueryable<CurrentTransformer> GetExpiredCurrentTransformers(int consumptionObjectId);

    /// <summary>
    /// Запрос на получение трансформаторов напряжения с закончившимся сроком поверки.
    /// </summary>
    /// <param name="consumptionObjectId">Id объекта потребления.</param>
    /// <returns>Запрос на получение трансформаторов напряжения с закончившимся сроком поверки.</returns>
    IQueryable<VoltageTransformer> GetExpiredVoltageTransformers(int consumptionObjectId);
}
