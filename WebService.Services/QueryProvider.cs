using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebService.Contracts;
using WebService.Contracts.Dtos;
using WebService.Domain;

namespace WebService.Services;

/// <summary>
/// Провайдер запросов.
/// </summary>
public class QueryProvider : Contracts.IQueryProvider
{
    private readonly IRepository<CalculationMeterByPeriod> _calculationMeterByPeriodRepository;
    private readonly IRepository<CurrentTransformer> _currentTransformerRepository;
    private readonly IRepository<MeasurementPoint> _measurementPointRepository;
    private readonly IRepository<Meter> _meterRepository;
    private readonly IRepository<VoltageTransformer> _voltageTransformerRepository;
    private readonly IMapper _mapper;

    public QueryProvider(
        IRepository<CalculationMeterByPeriod> calculationMeterByPeriodRepository,
        IRepository<CurrentTransformer> currentTransformerRepository,
        IRepository<MeasurementPoint> measurementPointRepository,
        IRepository<Meter> meterRepository,
        IRepository<VoltageTransformer> voltageTransformerRepository,
        IMapper mapper)
    {
        _calculationMeterByPeriodRepository = calculationMeterByPeriodRepository;
        _currentTransformerRepository = currentTransformerRepository;
        _measurementPointRepository = measurementPointRepository;
        _meterRepository = meterRepository;
        _voltageTransformerRepository = voltageTransformerRepository;
        _mapper = mapper;
    }


    /// <summary>
    /// Создание точки измерения.
    /// </summary>
    /// <param name="measurementPointCreateDto">ДТО для создания точки измерения.</param>
    /// <returns>Новая точка измерения.</returns>
    public async Task<MeasurementPoint> CreateMeasurementPoint(MeasurementPointCreateDto measurementPointCreateDto)
    {
        MeasurementPoint model = _mapper.Map<MeasurementPoint>(measurementPointCreateDto);
        await _measurementPointRepository.Add(model);
        return model;
    }

    /// <summary>
    /// Создание точки измерения.
    /// </summary>
    /// <param name="meterCreateDto">ДТО для создания счётчика электроэнергии.</param>
    /// <returns>Новый счётчик электроэнергии.</returns>
    public async Task<Meter> CreateMeter(MeterCreateDto meterCreateDto)
    {
        Meter model = _mapper.Map<Meter>(meterCreateDto);
        await _meterRepository.Add(model);
        return model;
    }

    /// <summary>
    /// Создание трансформатора тока.
    /// </summary>
    /// <param name="meterCreateDto">ДТО для создания трансформатора тока.</param>
    /// <returns>Новый трансформатор тока.</returns>
    public async Task<CurrentTransformer> CreateCurrentTransformer(CurrentTransformerCreateDto currentTransformerCreateDto)
    {
        CurrentTransformer model = _mapper.Map<CurrentTransformer>(currentTransformerCreateDto);
        await _currentTransformerRepository.Add(model);
        return model;
    }

    /// <summary>
    /// Создание трансформатора тока.
    /// </summary>
    /// <param name="meterCreateDto">ДТО для создания трансформатора напряжения.</param>
    /// <returns>Новый трансформатор напряжения.</returns>
    public async Task<VoltageTransformer> CreateVoltageTransformer(VoltageTransformerCreateDto voltageTransformerCreateDto)
    {
        VoltageTransformer model = _mapper.Map<VoltageTransformer>(voltageTransformerCreateDto);
        await _voltageTransformerRepository.Add(model);
        return model;
    }

    /// <summary>
    /// Запрос на получение расчетных приборов учета.
    /// </summary>
    /// <param name="year">Период учёта.</param>
    /// <returns>Запрос на получение расчетных приборов учета.</returns>
    public IQueryable<CalculationMeterByPeriod> GetCalculationMeters(int year) =>
        _calculationMeterByPeriodRepository
            .Get()
            .Include(x => x.Period)
            .Where(x =>
                x.Period.Start >= new DateTime(year, 1, 1) &&
                x.Period.End <= new DateTime(year, 12, 31))
            .Include(x => x.MeasurementPoint);

    /// <summary>
    /// Запрос на получение счетчиков с закончившимся сроком поверки.
    /// </summary>
    /// <param name="consumptionObjectId">Id объекта потребления.</param>
    /// <returns>Запрос на получение счетчиков с закончившимся сроком поверки.</returns>
    public IQueryable<Meter> GetExpiredMeters(int consumptionObjectId)
    {
        return _meterRepository
            .Get()
            .Include(x => x.MeasurementPoint)
            .ThenInclude(x => x.ConsumptionObject)
            .Where(x => 
                x.MeasurementPoint != null && 
                x.MeasurementPoint.ConsumptionObjectId == consumptionObjectId &&
                x.VerificationDate < DateTime.UtcNow);
    }

    /// <summary>
    /// Запрос на получение трансформаторов тока с закончившимся сроком поверки.
    /// </summary>
    /// <param name="consumptionObjectId">Id объекта потребления.</param>
    /// <returns>Запрос на получение трансформаторов тока с закончившимся сроком поверки.</returns>
    public IQueryable<CurrentTransformer> GetExpiredCurrentTransformers(int consumptionObjectId) =>
        _currentTransformerRepository
            .Get()
            .Include(x => x.MeasurementPoint)
            .ThenInclude(x => x.ConsumptionObject)
            .Where(x =>
                x.MeasurementPoint != null &&
                x.MeasurementPoint.ConsumptionObjectId == consumptionObjectId &&
                x.VerificationDate < DateTime.UtcNow);

    /// <summary>
    /// Запрос на получение трансформаторов напряжения с закончившимся сроком поверки.
    /// </summary>
    /// <param name="consumptionObjectId">Id объекта потребления.</param>
    /// <returns>Запрос на получение трансформаторов напряжения с закончившимся сроком поверки.</returns>
    public IQueryable<VoltageTransformer> GetExpiredVoltageTransformers(int consumptionObjectId) =>
        _voltageTransformerRepository
            .Get()
            .Include(x => x.MeasurementPoint)
            .ThenInclude(x => x.ConsumptionObject)
            .Where(x =>
                x.MeasurementPoint != null &&
                x.MeasurementPoint.ConsumptionObjectId == consumptionObjectId &&
                x.VerificationDate < DateTime.UtcNow);
}
