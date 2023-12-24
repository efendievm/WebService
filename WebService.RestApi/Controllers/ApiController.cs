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
        /// �����������.
        /// </summary>
        /// <param name="queryProvider">��������� ��������.</param>
        /// <param name="mapper">������.</param>
        /// <param name="logger">������.</param>
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
        /// �������� ����� ���������.
        /// </summary>
        /// <param name="measurementPointCreateDto">��� ��� �������� ����� ���������.</param>
        /// <returns>��� ��� ������ ������ �� ����� ���������.</returns>
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
        /// �������� ����� ���������.
        /// </summary>
        /// <param name="meterCreateDto">��� ��� �������� �������� ��������������.</param>
        /// <returns>��� ��� ������ ������ �� �������� ��������������.</returns>
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
        /// �������� �������������� ����.
        /// </summary>
        /// <param name="meterCreateDto">��� ��� �������� �������������� ����.</param>
        /// <returns>��� ��� ������ ������ �� �������������� ����.</returns>
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
        /// �������� �������������� ����.
        /// </summary>
        /// <param name="meterCreateDto">��� ��� �������� �������������� ����������.</param>
        /// <returns>��� ��� ������ ������ �� �������������� ����������.</returns>
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
        /// ��������� ��������� �������� �����.
        /// </summary>
        /// <param name="year">������ �����.</param>
        /// <returns>��������� ������ �� �������� �����.</returns>
        [HttpGet(Name = "GetCalculationMeters")]
        public async Task<ActionResult<IEnumerable<CalculationMeterReadDto>>> GetCalculationMeters(int year)
        {
            return await _queryProvider.GetCalculationMeters(year)
                .ProjectTo<CalculationMeterReadDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        /// <summary>
        /// ��������� ��������� � ������������� ������ �������.
        /// </summary>
        /// <param name="consumptionObjectId">Id ������� �����������.</param>
        /// <returns>��������� ������ �� ���������.</returns>
        [HttpGet(Name = "GetExpiredMeters")]
        public async Task<ActionResult<IEnumerable<MeterReadRichDto>>> GetExpiredMeters(int consumptionObjectId)
        {
            return await _queryProvider.GetExpiredMeters(consumptionObjectId)
                .ProjectTo<MeterReadRichDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        /// <summary>
        /// ��������� ��������������� ���� � ������������� ������ �������.
        /// </summary>
        /// <param name="consumptionObjectId">Id ������� �����������.</param>
        /// <returns>��������� ������ �� ���� ����������.</returns>
        [HttpGet(Name = "GetExpiredCurrentTransformers")]
        public async Task<ActionResult<IEnumerable<CurrentTransformerReadRichDto>>> GetExpiredCurrentTransformers(int consumptionObjectId)
        {
            return await _queryProvider.GetExpiredCurrentTransformers(consumptionObjectId)
                .ProjectTo<CurrentTransformerReadRichDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        /// <summary>
        /// ��������� ��������������� ���������� � ������������� ������ �������.
        /// </summary>
        /// <param name="consumptionObjectId">Id ������� �����������.</param>
        /// <returns>��������� ������ �� ��������������� ����������.</returns>
        [HttpGet(Name = "GetExpiredVoltageTransformers")]
        public async Task<ActionResult<IEnumerable<VoltageTransformerReadRichDto>>> GetExpiredVoltageTransformers(int consumptionObjectId)
        {
            return await _queryProvider.GetExpiredVoltageTransformers(consumptionObjectId)
                .ProjectTo<VoltageTransformerReadRichDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }
    }
}