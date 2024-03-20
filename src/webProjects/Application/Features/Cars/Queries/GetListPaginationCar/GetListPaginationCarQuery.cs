using Amazon.Runtime.Internal;
using Application.Features.Cars.Models;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using MediatR;

namespace Application.Features.Cars.Queries.GetListPaginationCar;

public class GetListPaginationCarQuery:IRequest<CarListModel>
{
    public PageRequest PageRequest { get; set; }

    
}
