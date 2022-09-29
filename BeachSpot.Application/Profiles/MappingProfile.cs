using AutoMapper;
using BeachSpot.Application.Features.Beaches.Commands.CreateBeach;
using BeachSpot.Application.Features.Beaches.Queries.GetBeachesList;
using BeachSpot.Application.Features.Beaches.Queries.GetBeachesListListWithSightings;
using BeachSpot.Application.Features.Sightings.Commands.CreateSighting;
using BeachSpot.Application.Features.Sightings.Commands.LikeSighting;
using BeachSpot.Application.Features.Sightings.Commands.UnlikeSighting;
using BeachSpot.Application.Features.Sightings.Queries.GetSightingDetails;
using BeachSpot.Application.Features.Sightings.Queries.GetSightingsList;
using BeachSpot.Domain.Entities;

namespace BeachSpot.Application.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Beach, BeachListVm>();
        CreateMap<Sighting, SightingsDto>()
           .ForMember(dto => dto.Username, opt => opt.MapFrom(ent => ent.User.Username))
           .ForMember(dto => dto.Email, opt => opt.MapFrom(ent => ent.User.Email));
        CreateMap<Beach, BeachSightingsListVm>();       

        CreateMap<Beach, CreateBeachCommandResponse>();
        CreateMap<CreateBeachCommand, Beach>();

        CreateMap<Sighting, CreateSightingCommandResponse>();
        CreateMap<CreateSightingCommand, Sighting>();
        CreateMap<User, CreateSightingUserDto>().ForMember(dto => dto.Name, opt => opt.MapFrom(ent => ent.Username));
        CreateMap<Beach, CreateSightingBeachDto>();

        CreateMap<Sighting, SightingListVm>()
            .ForMember(dto => dto.User, opt => opt.MapFrom(ent => ent.User.Username))
            .ForMember(dto => dto.Beach, opt => opt.MapFrom(ent => ent.Beach.Name));

        CreateMap<User, GetSightingDetailsDto>().ForMember(dto => dto.Name, opt => opt.MapFrom(ent => ent.Username));
        CreateMap<Beach, GetSightingDetailsDto>();
        CreateMap<Sighting, SightingDetailsVM>()
            .ForMember(dto => dto.User, opt => opt.MapFrom(ent => ent.User))
            .ForMember(dto => dto.Beach, opt => opt.MapFrom(ent => ent.Beach))
            .ForMember(dto => dto.Likes, opt => opt.MapFrom(ent => ent.Likes == null ? 0 : ent.Likes.Count()));

        CreateMap<Sighting, LikeSightingCommandResponse>()
            .ForMember(dto => dto.User, opt => opt.MapFrom(ent => ent.User.Username))
            .ForMember(dto => dto.Beach, opt => opt.MapFrom(ent => ent.Beach.Name))
            .ForMember(dto => dto.Likes, opt => opt.MapFrom(ent => ent.Likes == null ? 0 : ent.Likes.Count()));

        CreateMap<Sighting, UnlikeSightingCommandResponse>()
            .ForMember(dto => dto.User, opt => opt.MapFrom(ent => ent.User.Username))
            .ForMember(dto => dto.Beach, opt => opt.MapFrom(ent => ent.Beach.Name))
            .ForMember(dto => dto.Likes, opt => opt.MapFrom(ent => ent.Likes == null ? 0 : ent.Likes.Count()));
    }
}
