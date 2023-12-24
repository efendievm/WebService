using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WebService.Infrastructure;
using WebService.MockData;

namespace WebService.Migration;

/// <summary>
/// Инициализация тестовых данных.
/// </summary>
public class MockDataInitializer
{
    private readonly ILogger<MockDataInitializer> _logger;
    private readonly AppDbContext _dbContext;

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="dbContext">Контекст базы данных.</param>
    /// <param name="logger">Логгер.</param>
    public MockDataInitializer(AppDbContext dbContext, ILogger<MockDataInitializer> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    /// <summary>
    /// Загрузка тестовых данных.
    /// </summary>
    /// <returns></returns>
    public async Task LoadMockDataAsync()
    {
        _logger.LogInformation("Stating load mock data");
        if (!await _dbContext.Organizations.AnyAsync())
        {
            _logger.LogInformation("Starting load Organizations mock data");
            await _dbContext.Organizations.AddRangeAsync(Mock.Organizations);
            await _dbContext.SaveChangesAsync();
        }

        if (!await _dbContext.SubsidiaryOrganizations.AnyAsync())
        {
            _logger.LogInformation("Starting load SubsidiaryOrganizations mock data");
            await _dbContext.SubsidiaryOrganizations.AddRangeAsync(Mock.SubsidiaryOrganizations);
            await _dbContext.SaveChangesAsync();
        }

        if (!await _dbContext.ConsumptionObjects.AnyAsync())
        {
            _logger.LogInformation("Starting load ConsumptionObjects mock data");
            await _dbContext.ConsumptionObjects.AddRangeAsync(Mock.ConsumptionObjects);
            await _dbContext.SaveChangesAsync();
        }

        if (!await _dbContext.Meters.AnyAsync())
        {
            _logger.LogInformation("Starting load Meters mock data");
            await _dbContext.Meters.AddRangeAsync(Mock.Meters);
            await _dbContext.SaveChangesAsync();
        }

        if (!await _dbContext.CurrentTransformers.AnyAsync())
        {
            _logger.LogInformation("Starting load CurrentTransformers mock data");
            await _dbContext.CurrentTransformers.AddRangeAsync(Mock.CurrentTransformers);
            await _dbContext.SaveChangesAsync();
        }

        if (!await _dbContext.VoltageTransformers.AnyAsync())
        {
            _logger.LogInformation("Starting load VoltageTransformers mock data");
            await _dbContext.VoltageTransformers.AddRangeAsync(Mock.VoltageTransformers);
            await _dbContext.SaveChangesAsync();
        }

        if (!await _dbContext.MeasurementPoints.AnyAsync())
        {
            _logger.LogInformation("Starting load MeasurementPoints mock data");
            await _dbContext.MeasurementPoints.AddRangeAsync(Mock.MeasurementPoints);
            await _dbContext.SaveChangesAsync();
        }

        if (!await _dbContext.Periods.AnyAsync())
        {
            _logger.LogInformation("Starting load Periods mock data");
            await _dbContext.Periods.AddRangeAsync(Mock.Periods);
            await _dbContext.SaveChangesAsync();
        }

        if (!await _dbContext.CalculationMeters.AnyAsync())
        {
            _logger.LogInformation("Starting load CalculationMeters mock data");
            await _dbContext.CalculationMeters.AddRangeAsync(Mock.CalculationMeters);
            await _dbContext.SaveChangesAsync();
        }

        if (!await _dbContext.CalculationMeterByPeriods.AnyAsync())
        {
            _logger.LogInformation("Starting load CalculationMeterByPeriods mock data");
            await _dbContext.CalculationMeterByPeriods.AddRangeAsync(Mock.CalculationMeterByPeriods);
            await _dbContext.SaveChangesAsync();
        }

        if (!await _dbContext.SupplyPoints.AnyAsync())
        {
            _logger.LogInformation("Starting load SupplyPoints mock data");
            await _dbContext.SupplyPoints.AddRangeAsync(Mock.SupplyPoints);
            await _dbContext.SaveChangesAsync();
        }

        _logger.LogInformation("Mock data has been loaded");
    }
}