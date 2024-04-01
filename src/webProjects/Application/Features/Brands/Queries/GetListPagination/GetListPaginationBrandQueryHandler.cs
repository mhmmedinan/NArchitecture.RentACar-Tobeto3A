using Application.Features.Brands.Dtos;
using Application.Features.Brands.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;

namespace Application.Features.Brands.Queries.GetListPagination;

public class GetListPaginationBrandQueryHandler : IRequestHandler<GetListPaginationBrandQuery, List<GetListBrandResponse>>
{
    private readonly IBrandRepository _brandRepository;
    private readonly IMapper _mapper;

    public GetListPaginationBrandQueryHandler(IBrandRepository brandRepository, IMapper mapper)
    {
        _brandRepository = brandRepository;
        _mapper = mapper;
    }

    public async Task<List<GetListBrandResponse>> Handle(GetListPaginationBrandQuery request, CancellationToken cancellationToken)
    {
        List<Brand> brands = await _brandRepository.GetAllAsync
            ();
        List<GetListBrandResponse> responses = _mapper.Map<List<GetListBrandResponse>>(brands);
        return responses;
    }
}
