using Application.Features.Brands.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Brands.Commands.Delete;

public class DeleteBrandCommandHandler : IRequestHandler<DeleteBrandCommand, DeleteBrandResponse>
{
    private readonly IBrandRepository _brandRepository;
    private readonly IMapper _mapper;

    public DeleteBrandCommandHandler(IBrandRepository brandRepository, IMapper mapper)
    {
        _brandRepository = brandRepository;
        _mapper = mapper;
    }

    public async Task<DeleteBrandResponse> Handle(DeleteBrandCommand request, CancellationToken cancellationToken)
    {
        Brand? brand = await _brandRepository.GetAsync(x=>x.Id== request.Id);
        Brand deletedBrand = await _brandRepository.DeleteAsync(brand);
        DeleteBrandResponse deleteBrandResponse = _mapper.Map<DeleteBrandResponse>(deletedBrand);
        return deleteBrandResponse;
    }
}
