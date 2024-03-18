using Amazon.Runtime.Internal;
using Application.Features.Cars.Dtos;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Performance;
using MediatR;

namespace Application.Features.Cars.Command.Create;

public class CreateCarCommand:IRequest<CreateCarResponse>,IIntervalRequest,ICacheRemoverRequest
{
    public Guid ModelId { get; set; }
    public int ModelYear { get; set; }
    public string Plate { get; set; }
    public int State { get; set; }  // 1- Available 2- Rented 3-Under Maitenance
    public double DailyPrice { get; set; }

    public int Interval => 5;

    public bool BypassCache { get; }
    public string CacheKey => "car-list";

    public TimeSpan? SlidingExpiration { get; }
}

