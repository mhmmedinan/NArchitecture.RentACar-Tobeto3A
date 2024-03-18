using Amazon.Runtime.Internal;
using Application.Features.Models.Dtos;
using Core.Application.Pipelines.Caching;
using MediatR;

namespace Application.Features.Models.Queries.GetListModel;

public class GetListModelQuery : IRequest<List<GetListModelResponse>>, ICachableRequest
{
    public bool BypassCache { get; }

    public string CacheKey => "model-list";

    public TimeSpan? SlidingExpiration { get; }
}
