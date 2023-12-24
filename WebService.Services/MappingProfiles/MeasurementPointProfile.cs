using AutoMapper;
using WebService.Contracts.Dtos;
using WebService.Domain;

namespace WebService.Contracts.MappingProfiles;

/// <summary>
/// Настройка маппинга для <see cref="MeasurementPoint"/>.
/// </summary>
public class MeasurementPointProfile : Profile
{
    /// <summary>
    /// Конструктор.
    /// </summary>
    public MeasurementPointProfile()
    {
        CreateMap<MeasurementPointCreateDto, MeasurementPoint>();
        CreateMap<MeasurementPoint, MeasurementPointReadDto>();
    }
}
