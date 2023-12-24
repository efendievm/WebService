using AutoMapper;
using WebService.Contracts.Dtos;
using WebService.Domain;

namespace WebService.Contracts.MappingProfiles;

/// <summary>
/// Настройка маппинга для <see cref="VoltageTransformer"/>.
/// </summary>
public class VoltageTransformerProfile : Profile
{
    /// <summary>
    /// Конструктор.
    /// </summary>
    public VoltageTransformerProfile()
    {
        CreateMap<VoltageTransformerCreateDto, VoltageTransformer>();
        CreateMap<VoltageTransformer, VoltageTransformerReadRichDto>()
            .ForMember(dto => dto.MeasurementPointId, opt => opt.MapFrom(src => src.MeasurementPoint.Id))
            .ForMember(dto => dto.MeasurementPointName, opt => opt.MapFrom(src => src.MeasurementPoint.Name))
            .ForMember(dto => dto.ConsumptionObjectId, opt => opt.MapFrom(src => src.MeasurementPoint.ConsumptionObject.Id))
            .ForMember(dto => dto.ConsumptionObjectName, opt => opt.MapFrom(src => src.MeasurementPoint.ConsumptionObject.Name))
            .ForMember(dto => dto.TransformerType, opt => opt.MapFrom(EnumHelper.CreateEnumDescriptionExpression<VoltageTransformer, VoltageTransformerType>(src => src.TransformerType)));
    }
}
