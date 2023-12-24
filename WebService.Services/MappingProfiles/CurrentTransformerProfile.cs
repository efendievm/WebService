using AutoMapper;
using WebService.Contracts.Dtos;
using WebService.Domain;

namespace WebService.Contracts.MappingProfiles;

/// <summary>
/// Настройка маппинга для <see cref="CurrentTransformer"/>.
/// </summary>
public class CurrentTransformerProfile : Profile
{
    /// <summary>
    /// Конструктор.
    /// </summary>
    public CurrentTransformerProfile()
    {
        CreateMap<CurrentTransformerCreateDto, CurrentTransformer>();
        CreateMap<CurrentTransformer, CurrentTransformerReadRichDto>()
            .ForMember(dto => dto.MeasurementPointId, opt => opt.MapFrom(src => src.MeasurementPoint.Id))
            .ForMember(dto => dto.MeasurementPointName, opt => opt.MapFrom(src => src.MeasurementPoint.Name))
            .ForMember(dto => dto.ConsumptionObjectId, opt => opt.MapFrom(src => src.MeasurementPoint.ConsumptionObject.Id))
            .ForMember(dto => dto.ConsumptionObjectName, opt => opt.MapFrom(src => src.MeasurementPoint.ConsumptionObject.Name))
            .ForMember(dto => dto.TransformerType, opt => opt.MapFrom(EnumHelper.CreateEnumDescriptionExpression<CurrentTransformer, CurrentTransformerType>(src => src.TransformerType)));
    }
}
