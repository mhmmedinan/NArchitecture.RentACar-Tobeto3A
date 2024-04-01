using Application.Features.Cars.Dtos;
using Application.Features.Cars.Models;
using Core.Application.Requests;
using MediatR;

namespace Application.Features.Cars.Queries.GetListCarByModelId;

public class GetListCarByModelIdQuery:IRequest<CarListModel>
{
    public PageRequest PageRequest { get; set; } 
    public Guid ModelId { get; set; }
}
