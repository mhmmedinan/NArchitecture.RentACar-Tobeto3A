using Application.Features.Cars.Models;
using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using MediatR;

namespace Application.Features.Cars.Queries.GetListPaginationCar;

public class GetListPaginationCarQuery:IRequest<CarListModel>,ISecuredRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => ["admin"];
}
