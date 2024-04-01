using Application.Features.Brands.Dtos;
using Application.Features.Brands.Models;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using MediatR;

namespace Application.Features.Brands.Queries.GetListPagination;

public class GetListPaginationBrandQuery : IRequest<List<GetListBrandResponse>>
{
   
}
