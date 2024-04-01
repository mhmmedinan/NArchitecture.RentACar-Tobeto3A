using Amazon.Runtime.Internal;
using Application.Features.Models.Dtos;
using Core.Application.Pipelines.Caching;
using MediatR;

namespace Application.Features.Models.Queries.GetListModel;

public class GetListModelQuery : IRequest<List<GetListModelResponse>>
{
    public Guid BrandId { get; set; }
}
