using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WebService.Infrastructure;

namespace WebService.Migration;

/// <summary>
/// Сервис миграций.
/// </summary>
public class MigrationService
{
    private readonly ILogger<MigrationService> _logger;
    private readonly AppDbContext _dbContext;

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="dbContext">Контекст базы данных.</param>
    /// <param name="logger">Логгер.</param>
    public MigrationService(AppDbContext dbContext, ILogger<MigrationService> logger)
    {
        _logger = logger;
        _dbContext = dbContext;
    }

    /// <summary>
    /// Применение миграций.
    /// </summary>
    /// <returns></returns>
    public async Task ApplyMigrationsAsync()
    {
        try
        {
            _logger.LogInformation("Start Applying Migrations");
            await _dbContext.Database.MigrateAsync();
            _logger.LogInformation("Migrations have been applied");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while initialising the database");
            throw;
        }
    }
}