using Application.Features.Cars.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Cars.Command.Create;

public class CreateCarCommandHandler : IRequestHandler<CreateCarCommand, CreateCarResponse>
{
    private readonly ICarRepository _carRepository;
    private readonly IMapper _mapper;

    public CreateCarCommandHandler(ICarRepository carRepository, IMapper mapper)
    {
        _carRepository = carRepository;
        _mapper = mapper;
    }

    public async Task<CreateCarResponse> Handle(CreateCarCommand request, CancellationToken cancellationToken)
    {
        Car mappedCar = _mapper.Map<Car>(request);
        Car createdCar = await _carRepository.AddAsync(mappedCar);
        CreateCarResponse createCarResponse = _mapper.Map<CreateCarResponse>(createdCar);
        return createCarResponse;
    }
}
