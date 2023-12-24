using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebService.Contracts.Dtos;
using WebService.Domain;

namespace WebService.RestApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ApiController : ControllerBase
    {
        private readonly Contracts.IQueryProvider _queryProvider;
        private readonly IMapper _mapper;
        private readonly ILogger<ApiController> _logger;

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="queryProvider">Провайдер запросов.</param>
        /// <param name="mapper">Маппер.</param>
        /// <param name="logger">Логгер.</param>
        public ApiController(
            Contracts.IQueryProvider queryProvider,
            IMapper mapper,
            ILogger<ApiController> logger)
        {
            _queryProvider = queryProvider;
            _mapper = mapper;
            _logger = logger;
        }

        /// <summary>
        /// Создание точки измерения.
        /// </summary>
        /// <param name="measurementPointCreateDto">ДТО для создания точки измерения.</param>
        /// <returns>ДТО для чтения данных по точке измерения.</returns>
        [HttpPost(Name = "PostMeasurementPoint")]
        public async Task<ActionResult<MeasurementPointReadDto>> PostMeasurementPoint(MeasurementPointCreateDto measurementPointCreateDto)
        {
            // ToDo: Return BadRequest if unique constraint (e.g. duplicate ConsumptionObjectId) is provided.
            try
            {
                MeasurementPoint model = await _queryProvider.CreateMeasurementPoint(measurementPointCreateDto);
                return Ok(_mapper.Map<MeasurementPointReadDto>(model));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Создание точки измерения.
        /// </summary>
        /// <param name="meterCreateDto">ДТО для создания счётчика электроэнергии.</param>
        /// <returns>ДТО для чтения данных по счётчику электроэнергии.</returns>
        [HttpPost(Name = "PostMeter")]
        public async Task<ActionResult<MeterReadRichDto>> PostMeter(MeterCreateDto meterCreateDto)
        {
            try
            {
                Meter model = await _queryProvider.CreateMeter(meterCreateDto);
                return Ok(_mapper.Map<MeterReadRichDto>(model));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Создание трансформатора тока.
        /// </summary>
        /// <param name="meterCreateDto">ДТО для создания трансформатора тока.</param>
        /// <returns>ДТО для чтения данных по трансформатору тока.</returns>
        [HttpPost(Name = "PostCurrentTransformer")]
        public async Task<ActionResult<CurrentTransformerReadRichDto>> PostCurrentTransformer(CurrentTransformerCreateDto currentTransformerCreateDto)
        {
            try
            {
                CurrentTransformer model = await _queryProvider.CreateCurrentTransformer(currentTransformerCreateDto);
                return Ok(_mapper.Map<CurrentTransformerReadRichDto>(model));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Создание трансформатора тока.
        /// </summary>
        /// <param name="meterCreateDto">ДТО для создания трансформатора напряжения.</param>
        /// <returns>ДТО для чтения данных по трансформатору напряжения.</returns>
        [HttpPost(Name = "PostVoltageTransformer")]
        public async Task<ActionResult<VoltageTransformerReadRichDto>> PostVoltageTransformer(VoltageTransformerCreateDto voltageTransformerCreateDto)
        {
            try
            {
                VoltageTransformer model = await _queryProvider.CreateVoltageTransformer(voltageTransformerCreateDto);
                return _mapper.Map<VoltageTransformerReadRichDto>(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Получение расчетных приборов учета.
        /// </summary>
        /// <param name="year">Период учёта.</param>
        /// <returns>Коллекция данных по приборам учета.</returns>
        [HttpGet(Name = "GetCalculationMeters")]
        public async Task<ActionResult<IEnumerable<CalculationMeterReadDto>>> GetCalculationMeters(int year)
        {
            return await _queryProvider.GetCalculationMeters(year)
                .ProjectTo<CalculationMeterReadDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        /// <summary>
        /// Получение счетчиков с закончившимся сроком поверки.
        /// </summary>
        /// <param name="consumptionObjectId">Id объекта потребления.</param>
        /// <returns>Коллекция данных по счётчикам.</returns>
        [HttpGet(Name = "GetExpiredMeters")]
        public async Task<ActionResult<IEnumerable<MeterReadRichDto>>> GetExpiredMeters(int consumptionObjectId)
        {
            return await _queryProvider.GetExpiredMeters(consumptionObjectId)
                .ProjectTo<MeterReadRichDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        /// <summary>
        /// Получение трансформаторов тока с закончившимся сроком поверки.
        /// </summary>
        /// <param name="consumptionObjectId">Id объекта потребления.</param>
        /// <returns>Коллекция данных по тока напряжения.</returns>
        [HttpGet(Name = "GetExpiredCurrentTransformers")]
        public async Task<ActionResult<IEnumerable<CurrentTransformerReadRichDto>>> GetExpiredCurrentTransformers(int consumptionObjectId)
        {
            return await _queryProvider.GetExpiredCurrentTransformers(consumptionObjectId)
                .ProjectTo<CurrentTransformerReadRichDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        /// <summary>
        /// Получение трансформаторов напряжения с закончившимся сроком поверки.
        /// </summary>
        /// <param name="consumptionObjectId">Id объекта потребления.</param>
        /// <returns>Коллекция данных по трансформаторам напряжения.</returns>
        [HttpGet(Name = "GetExpiredVoltageTransformers")]
        public async Task<ActionResult<IEnumerable<VoltageTransformerReadRichDto>>> GetExpiredVoltageTransformers(int consumptionObjectId)
        {
            return await _queryProvider.GetExpiredVoltageTransformers(consumptionObjectId)
                .ProjectTo<VoltageTransformerReadRichDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }
    }
}