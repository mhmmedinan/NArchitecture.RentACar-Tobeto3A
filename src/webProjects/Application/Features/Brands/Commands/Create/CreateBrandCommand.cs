using Application.Features.Brands.Dtos;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Performance;
using MediatR;

namespace Application.Features.Brands.Commands.Create;

public class CreateBrandCommand:IRequest<CreatedBrandResponse>,IIntervalRequest,ILoggableRequest
{
    public string Name { get; set; }

    public int Interval => 1;
}
