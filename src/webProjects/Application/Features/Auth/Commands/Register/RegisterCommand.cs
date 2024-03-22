using Application.Features.Auth.Dtos;
using Core.Security.Dtos;
using MediatR;

namespace Application.Features.Auth.Commands.Register;

public class RegisterCommand:IRequest<RegisteredDto>
{
    public UserForRegisterDto UserForRegisterDto { get; set; }
    public string IPAddress { get; set; }
}

