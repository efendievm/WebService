using AutoMapper;
using WebService.Contracts.Dtos;
using WebService.Domain;

namespace WebService.Contracts.MappingProfiles;

/// <summary>
/// Настройка маппинга для <see cref="CalculationMeter"/>.
/// </summary>
public class CalculationMeterProfile : Profile
{
    /// <summary>
    /// Конструктор.
    /// </summary>
    public CalculationMeterProfile()
    {
        CreateMap<CalculationMeterByPeriod, CalculationMeterReadDto>()
            .ForMember(dto => dto.MeasurementPointName, opt => opt.MapFrom(src => src.MeasurementPoint.Name))
            .ForMember(dto => dto.Start, opt => opt.MapFrom(src => src.Period.Start))
            .ForMember(dto => dto.End, opt => opt.MapFrom(src => src.Period.End));
    }
}
