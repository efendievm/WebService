using WebService.Domain;

namespace WebService.MockData;

/// <summary>
/// Тестовые данные.
/// </summary>
public static class Mock
{
    /// <summary>
    /// Тестовые данные для <see cref="Organization"/>.
    /// </summary>
    public static IList<Organization> Organizations => new List<Organization>
    {
        new() { Id = 1, Name = "Организация 1", Address = "Адрес" },
        new() { Id = 2, Name = "Организация 2", Address = "Адрес" }
    };

    /// <summary>
    /// Тестовые данные для <see cref="SubsidiaryOrganization"/>.
    /// </summary>
    public static IList<SubsidiaryOrganization> SubsidiaryOrganizations => new List<SubsidiaryOrganization>
    {
        new() { Id = 1, Name = "Дочерняя организация 1", Address = "Адрес", OrganizationId = 1 },
        new() { Id = 2, Name = "Дочерняя организация 1", Address = "Адрес",  OrganizationId = 1 },
        new() { Id = 3, Name = "Дочерняя организация 3", Address = "Адрес", OrganizationId = 2 },
        new() { Id = 4, Name = "Дочерняя организация 4", Address = "Адрес",  OrganizationId = 2 }
    };

    /// <summary>
    /// Тестовые данные для <see cref="ConsumptionObject"/>.
    /// </summary>
    public static IList<ConsumptionObject> ConsumptionObjects => new List<ConsumptionObject>
    {
        new() { Id = 1, Name = "Объект потребления 1", Address = "Адрес", SubsidiaryOrganizationId = 1 },
        new() { Id = 2, Name = "Объект потребления 2", Address = "Адрес",  SubsidiaryOrganizationId = 2 },
        new() { Id = 3, Name = "Объект потребления 3", Address = "Адрес", SubsidiaryOrganizationId = 3 },
        new() { Id = 4, Name = "Объект потребления 4", Address = "Адрес",  SubsidiaryOrganizationId = 4 }
    };

    /// <summary>
    /// Тестовые данные для <see cref="Meter"/>.
    /// </summary>
    public static IList<Meter> Meters => new List<Meter>
    {
        new() { Id = 1, Number = 11111, MeterType = MeterType.Electronic, VerificationDate = DateTime.UtcNow.AddYears(1) },
        new() { Id = 2, Number = 22222, MeterType = MeterType.Electronic, VerificationDate = DateTime.UtcNow.AddYears(-1) },
        new() { Id = 3, Number = 33333, MeterType = MeterType.Induction, VerificationDate = DateTime.UtcNow.AddYears(1) },
        new() { Id = 4, Number = 44444, MeterType = MeterType.Induction, VerificationDate = DateTime.UtcNow.AddYears(-1) },
        new() { Id = 5, Number = 55555, MeterType = MeterType.Induction, VerificationDate = DateTime.UtcNow.AddYears(-1) }
    };

    /// <summary>
    /// Тестовые данные для <see cref="CurrentTransformer"/>.
    /// </summary>
    public static IList<CurrentTransformer> CurrentTransformers => new List<CurrentTransformer>
    {
        new () { Id = 1, Number = 11111, TransformerType = CurrentTransformerType.Core, VerificationDate = DateTime.UtcNow.AddYears(1) },
        new() { Id = 2, Number = 22222, TransformerType = CurrentTransformerType.Winding, VerificationDate = DateTime.UtcNow.AddYears(-1) },
        new() { Id = 3, Number = 33333, TransformerType = CurrentTransformerType.Toroidal, VerificationDate = DateTime.UtcNow.AddYears(1) },
        new() { Id = 4, Number = 44444, TransformerType = CurrentTransformerType.Core, VerificationDate = DateTime.UtcNow.AddYears(-1) },
        new() { Id = 5, Number = 55555, TransformerType = CurrentTransformerType.Core, VerificationDate = DateTime.UtcNow.AddYears(-1) }
    };

    /// <summary>
    /// Тестовые данные для <see cref="VoltageTransformer"/>.
    /// </summary>
    public static IList<VoltageTransformer> VoltageTransformers => new List<VoltageTransformer>
    {
        new() { Id = 1, Number = 11111, TransformerType = VoltageTransformerType.Optoelectronic, VerificationDate = DateTime.UtcNow.AddYears(1) },
        new() { Id = 2, Number = 22222, TransformerType = VoltageTransformerType.Capacitive, VerificationDate = DateTime.UtcNow.AddYears(-1) },
        new() { Id = 3, Number = 33333, TransformerType = VoltageTransformerType.Grounded, VerificationDate = DateTime.UtcNow.AddYears(1) },
        new() { Id = 4, Number = 44444, TransformerType = VoltageTransformerType.Cascade, VerificationDate = DateTime.UtcNow.AddYears(-1) },
        new() { Id = 5, Number = 55555, TransformerType = VoltageTransformerType.Cascade, VerificationDate = DateTime.UtcNow.AddYears(-1) }
    };

    /// <summary>
    /// Тестовые данные для <see cref="MeasurementPoint"/>.
    /// </summary>
    public static IList<MeasurementPoint> MeasurementPoints => new List<MeasurementPoint>
    {
        new() { Id = 1, Name = "Точка измерения 1", ConsumptionObjectId = 1, MeterId = 1, CurrentTransformerId = 1, VoltageTransformerId = 1 },
        new() { Id = 2, Name = "Точка измерения 2", ConsumptionObjectId = 1, MeterId = 2, CurrentTransformerId = 2, VoltageTransformerId = 2 },
        new() { Id = 3, Name = "Точка измерения 3", ConsumptionObjectId = 3, MeterId = 3, CurrentTransformerId = 3, VoltageTransformerId = 3 },
        new() { Id = 4, Name = "Точка измерения 4", ConsumptionObjectId = 1, MeterId = 4, CurrentTransformerId = 4, VoltageTransformerId = 4 }
    };

    /// <summary>
    /// Тестовые данные для <see cref="Period"/>.
    /// </summary>
    public static IList<Period> Periods => new List<Period>
    {
        new() { Id = 1, Start = new DateTime(2018, 1, 1), End = new DateTime(2018, 12, 31) },
        new() { Id = 2, Start = new DateTime(2019, 1, 1), End = new DateTime(2019, 12, 31) }
    };

    /// <summary>
    /// Тестовые данные для <see cref="CalculationMeter"/>.
    /// </summary>
    public static IList<CalculationMeter> CalculationMeters => new List<CalculationMeter>
    {
        new() { Id = 1 },
        new() { Id = 2 },
        new() { Id = 3 },
        new() { Id = 4 }
    };

    /// <summary>
    /// Тестовые данные для <see cref="CalculationMeterByPeriod"/>.
    /// </summary>
    public static IList<CalculationMeterByPeriod> CalculationMeterByPeriods => new List<CalculationMeterByPeriod>
    {
        new() { Id = 1, MeasurementPointId = 1, CalculationMeterId = 1, PeriodId = 1 },
        new() { Id = 2, MeasurementPointId = 2, CalculationMeterId = 2, PeriodId = 1 },
        new() { Id = 3, MeasurementPointId = 3, CalculationMeterId = 3, PeriodId = 1 },
        new() { Id = 4, MeasurementPointId = 4, CalculationMeterId = 4, PeriodId = 2 }
    };

    /// <summary>
    /// Тестовые данные для <see cref="SupplyPoint"/>.
    /// </summary>
    public static IList<SupplyPoint> SupplyPoints => new List<SupplyPoint>
    {
        new() { Id = 1, Name = "Точка поставки 1", ConsumptionObjectId = 1 },
        new() { Id = 2, Name = "Точка поставки 2", ConsumptionObjectId = 2 },
        new() { Id = 3, Name = "Точка поставки 3", ConsumptionObjectId = 3 },
        new() { Id = 4, Name = "Точка поставки 4", ConsumptionObjectId = 4 }
    };
}