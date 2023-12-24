using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebService.Contracts.MappingProfiles;

namespace WebService.Services;

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
    public static void AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAutoMapper(typeof(CalculationMeterProfile))
                .AddAutoMapper(typeof(CurrentTransformerProfile))
                .AddAutoMapper(typeof(MeasurementPointProfile))
                .AddAutoMapper(typeof(MeterProfile))
                .AddAutoMapper(typeof(VoltageTransformerProfile));

        services.AddScoped<Contracts.IQueryProvider, QueryProvider>();
    }
}