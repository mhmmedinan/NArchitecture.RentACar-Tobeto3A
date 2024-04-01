using Application.Features.Cars.Dtos;
using Application.Features.Cars.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Cars.Queries.GetListCarByModelId;

public class GetListCarByModelIdQueryHandler : IRequestHandler<GetListCarByModelIdQuery, CarListModel>
{
    private readonly ICarRepository _carRepository;
    private readonly IMapper _mapper;

    public GetListCarByModelIdQueryHandler(ICarRepository carRepository, IMapper mapper)
    {
        _carRepository = carRepository;
        _mapper = mapper;
    }

    public async Task<CarListModel> Handle(GetListCarByModelIdQuery request, CancellationToken cancellationToken)
    {
        IPaginate<Car> cars = await _carRepository.GetListPaginateAsync
              (index: request.PageRequest.Page, size: request.PageRequest.PageSize, include: x => x.Include(x => x.Model).Include(x => x.Model.Brand).Include(x => x.CarImages),predicate:x=>x.ModelId==request.ModelId);
        CarListModel carListModel = _mapper.Map<CarListModel>(cars);
        return carListModel;
    }
}
