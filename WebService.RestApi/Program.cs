using Microsoft.EntityFrameworkCore;
using System.Text;
using WebService.Services;
using WebService.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddServices(builder.Configuration);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(8051);
    options.ListenAnyIP(8050, configure => configure.UseHttps("WebService.RestApi.pfx", "69b5db20-8173-46db-a4f0-dbb1883efc56"));
});

var app = builder.Build();

// ��� ���������� ������� ������ � �� Id ��������� ������������ ��������. ��� ����� ������� Id � �������� �� ����������������
// � ���������� �������� ��������� �������� ��������� ������ �������, ����� ��� ���������� ����� ��������� ��������� ������
// ������������ ��������� ������.
using (var scope = app.Services.CreateScope())
{
    AppDbContext dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    StringBuilder sql = new();
    foreach (var property in dbContext.GetType().GetProperties())
    {
        Type setType = property.PropertyType;
        bool isDbSet = setType.IsGenericType && (typeof(DbSet<>).IsAssignableFrom(setType.GetGenericTypeDefinition()));
        if (isDbSet)
        {
            string tableName = property.Name;
            sql.AppendLine($"SELECT SETVAL('public.\"{tableName}_Id_seq\"', (SELECT MAX(\"Id\") FROM public.\"{tableName}\"));");
        }
    }

    // ������ RestApi ����� ����������� �� ����, ��� �������� ������ ������ Migration, ��� �������� � ������ ���������� �������,
    // �.�. �� ��� ��������� �� �������� ���������.
    int attempts = 0;
    while(attempts++ < 5)
    {
        try
        {
            dbContext.Database.ExecuteSqlRaw(sql.ToString());
            break;
        }
        catch { }
        await Task.Delay(2000);
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
