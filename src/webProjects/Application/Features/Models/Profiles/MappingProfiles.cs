using Application.Features.Models.Commands.Create;
using Application.Features.Models.Dtos;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.Models.Profiles;

public class MappingProfiles:Profile
{
    public MappingProfiles()
    {
        CreateMap<Model, CreateModelCommand>().ReverseMap();
        CreateMap<Model, CreateModelResponse>().ReverseMap();
        CreateMap<Model, GetListModelResponse>().ReverseMap();
    }
}
