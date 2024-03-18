using Application.Features.Models.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Models.Commands.Create;

public class CreateModelCommandHandler : IRequestHandler<CreateModelCommand, CreateModelResponse>
{
    private readonly IModelRepository _repository;
    private readonly IMapper _mapper;

    public CreateModelCommandHandler(IModelRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<CreateModelResponse> Handle(CreateModelCommand request, CancellationToken cancellationToken)
    {
        Model mappedModel = _mapper.Map<Model>(request);
        Model createdModel = await _repository.AddAsync(mappedModel);
        CreateModelResponse response = _mapper.Map<CreateModelResponse>(createdModel);
        return response;
    }
}
