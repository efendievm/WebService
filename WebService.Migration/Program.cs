using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Extensions.Logging;
using WebService.Migration;
using WebService.Infrastructure;

var configuration = new ConfigurationBuilder()
    .AddEnvironmentVariables()
    .Build();

ServiceCollection services = new();

services.AddInfrastructure(configuration);

services.AddScoped<MigrationService>();
services.AddScoped<MockDataInitializer>();


var loggerConfiguration = new LoggerConfiguration()
    .ReadFrom.Configuration(configuration)
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .MinimumLevel.Information();

var serviceProvider = services
    .AddLogging()
    .BuildServiceProvider();

serviceProvider
    .GetService<ILoggerFactory>()
        ?.AddProvider(new SerilogLoggerProvider(loggerConfiguration.CreateLogger()));

var migrationService = serviceProvider.GetRequiredService<MigrationService>();
await migrationService.ApplyMigrationsAsync();


if (Convert.ToBoolean(configuration["AppSettings:LoadMockData"]))
{
    MockDataInitializer applicationDbContextInitializer = serviceProvider.GetRequiredService<MockDataInitializer>();
    await applicationDbContextInitializer.LoadMockDataAsync();
}
