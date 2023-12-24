using AutoMapper;
using WebService.Contracts.Dtos;
using WebService.Domain;

namespace WebService.Contracts.MappingProfiles;

/// <summary>
/// Настройка маппинга для <see cref="Meter"/>.
/// </summary>
public class MeterProfile : Profile
{
    /// <summary>
    /// Конструктор.
    /// </summary>
    public MeterProfile()
    {
        CreateMap<MeterCreateDto, Meter>();
        CreateMap<Meter, MeterReadRichDto>()
            .ForMember(dto => dto.MeasurementPointId, opt => opt.MapFrom(src => src.MeasurementPoint.Id))
            .ForMember(dto => dto.MeasurementPointName, opt => opt.MapFrom(src => src.MeasurementPoint.Name))
            .ForMember(dto => dto.ConsumptionObjectId, opt => opt.MapFrom(src => src.MeasurementPoint.ConsumptionObject.Id))
            .ForMember(dto => dto.ConsumptionObjectName, opt => opt.MapFrom(src => src.MeasurementPoint.ConsumptionObject.Name))
            .ForMember(dto => dto.MeterType, opt => opt.MapFrom(EnumHelper.CreateEnumDescriptionExpression<Meter, MeterType>(src => src.MeterType)));
    }
}
