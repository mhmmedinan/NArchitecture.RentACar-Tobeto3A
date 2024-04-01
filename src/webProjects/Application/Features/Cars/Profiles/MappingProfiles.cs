using Application.Features.Cars.Command.Create;
using Application.Features.Cars.Dtos;
using Application.Features.Cars.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.Cars.Profiles;

public class MappingProfiles:Profile
{
    public MappingProfiles()
    {
        CreateMap<Car, CreateCarCommand>().ReverseMap();
        CreateMap<Car, CreateCarResponse>().ReverseMap();
        CreateMap<Car, GetListCarResponse>()
            .ForMember(destinationMember: x => x.BrandName, memberOptions: opt => opt.MapFrom(x => x.Model.Brand.Name))
            .ForMember(destinationMember: x => x.ImagePath, memberOptions: opt => opt.MapFrom(x => x.CarImages.FirstOrDefault().ImagePath));
        CreateMap<IPaginate<Car>, CarListModel>().ReverseMap();
    }
}
