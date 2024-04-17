using Amazon.Runtime.Internal;
using Application.Features.Brands.Dtos;
using MediatR;

namespace Application.Features.Brands.Commands.Delete;

public class DeleteBrandCommand:IRequest<DeleteBrandResponse>
{
    public Guid Id { get; set; }
}
