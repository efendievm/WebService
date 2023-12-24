using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebService.Contracts;
using WebService.Domain;
using WebService.Infrastructure.Repositories;

namespace WebService.Infrastructure;

/// <summary>
/// Методы расширения для внедрения зависимостей.
/// </summary>
public static class DependencyInjection
{
    /// <summary>
    /// Внедрение зависимостей.
    /// </summary>
    /// <param name="services">Сервисы.</param>
    /// <param name="configuration">Конфигурация.</param>
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        string? connectionString = configuration["AppSettings:DbContextSettings:ConnectionString"];
        services.AddDbContext<AppDbContext>(opts => opts.UseNpgsql(connectionString));

        services.AddScoped<IRepository<CalculationMeterByPeriod>, CalculationMeterByPeriodRepository>()
                .AddScoped<IRepository<CurrentTransformer>, CurrentTransformerRepository>()
                .AddScoped<IRepository<MeasurementPoint>, MeasurementPointRepository>()
                .AddScoped<IRepository<Meter>, MeterRepository>()
                .AddScoped<IRepository<VoltageTransformer>, VoltageTransformerRepository>();
    }
}
