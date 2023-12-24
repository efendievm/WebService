using AutoFixture.AutoMoq;
using AutoFixture;
using AutoMapper;
using Moq;
using WebService.Domain;
using Xunit;
using WebService.Contracts.Dtos;
using WebService.Contracts;
using WebService.Services;

namespace WebService.Tests;

public class QueryProviderTest
{
    private readonly IFixture _fixture;
    private readonly Mock<IRepository<CalculationMeterByPeriod>> _calculationMeterByPeriodRepository;
    private readonly Mock<IRepository<Meter>> _meterRepository;
    private readonly Mock<IMapper> _mapper;
    private readonly QueryProvider _provider;

    public QueryProviderTest()
    {
        _fixture = new Fixture();
        _fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList().ForEach(b =>
            _fixture.Behaviors.Remove(b));
        _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
        _fixture.Customize(new AutoMoqCustomization());

        _calculationMeterByPeriodRepository = new Mock<IRepository<CalculationMeterByPeriod>>();
        _meterRepository = new Mock<IRepository<Meter>>();

        IList<Period> periods = MockData.Mock.Periods;
        IList<MeasurementPoint> measurementPoints = MockData.Mock.MeasurementPoints;
        IList<CalculationMeter> calculationMeters = MockData.Mock.CalculationMeters;
        IList<ConsumptionObject> consumptionObjects = MockData.Mock.ConsumptionObjects;
        IList<CalculationMeterByPeriod> calculationMeterByPeriods = MockData.Mock.CalculationMeterByPeriods;
        IList<Meter> meters = MockData.Mock.Meters;
        foreach (var measurementPoint in measurementPoints)
        {
            measurementPoint.ConsumptionObject = consumptionObjects.First(x => x.Id == measurementPoint.ConsumptionObjectId);
            measurementPoint.Meter = meters.First(x => x.Id == measurementPoint.MeterId);
            measurementPoint.Meter.MeasurementPoint = measurementPoint;
        }

        foreach (var calculationMeterByPeriod in calculationMeterByPeriods)
        {
            calculationMeterByPeriod.MeasurementPoint = measurementPoints.First(x => x.Id == calculationMeterByPeriod.MeasurementPointId);
            calculationMeterByPeriod.MeasurementPoint.ConsumptionObject = consumptionObjects.First(
                x => x.Id == calculationMeterByPeriod.MeasurementPoint.ConsumptionObjectId);
            calculationMeterByPeriod.CalculationMeter = calculationMeters.First(x => x.Id == calculationMeterByPeriod.CalculationMeterId);
            calculationMeterByPeriod.Period = periods.First(x => x.Id == calculationMeterByPeriod.PeriodId);
        }

        _calculationMeterByPeriodRepository.Setup(repo => repo.Get()).Returns(calculationMeterByPeriods.AsQueryable());
        _meterRepository.Setup(repo => repo.Get()).Returns(meters.AsQueryable());

        _mapper = new Mock<IMapper>();
        _provider = new(
            _calculationMeterByPeriodRepository.Object,
            new Mock<IRepository<CurrentTransformer>>().Object,
            new Mock<IRepository<MeasurementPoint>>().Object,
            _meterRepository.Object,
            new Mock<IRepository<VoltageTransformer>>().Object,
            _mapper.Object
        );
    }

    [Fact]
    public async Task CreateMeter_EntityAdded()
    {
        // Arrange
        CancellationToken token = default;
        MeterCreateDto createDto = _fixture.Create<MeterCreateDto>();
        Meter mappedEntity = _fixture.Create<Meter>();
        _mapper.Setup(mapper => mapper.Map<Meter>(createDto)).Returns(mappedEntity);

        // Act
        Meter entity = await _provider.CreateMeter(createDto);

        // Assert
        Assert.NotNull(entity);
        _meterRepository.Verify(repo => repo.Add(mappedEntity, token), Times.Once);
        Assert.Equal(mappedEntity, entity);
    }

    [Fact]
    public void GetCalculationMeters_ReturnsCollection()
    {
        // Arrange
        int year = 2018;

        // Act
        IEnumerable<CalculationMeterByPeriod> response = _provider.GetCalculationMeters(year).ToList();

        // Assert
        Assert.NotNull(response);
        Assert.Equal(3, response.Count());
        Assert.Contains(response, x => x.Id == 1);
        Assert.Contains(response, x => x.Id == 2);
        Assert.Contains(response, x => x.Id == 3);
    }

    [Fact]
    public void GetExpiredMeters_ReturnsCollection()
    {
        // Arrange
        int consumptionObjectId = 1;

        // Act
        IEnumerable<Meter> response = _provider.GetExpiredMeters(consumptionObjectId).ToList();

        // Assert
        Assert.NotNull(response);
        Assert.Equal(2, response.Count());
        Assert.Contains(response, x => x.Id == 2);
        Assert.Contains(response, x => x.Id == 4);
    }
}
