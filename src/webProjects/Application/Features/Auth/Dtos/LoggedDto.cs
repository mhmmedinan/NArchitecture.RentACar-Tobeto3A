using Core.Security.Entities;
using Core.Security.Enums;
using Core.Security.JWT;

namespace Application.Features.Auth.Dtos;

public class LoggedDto
{
    public AccessToken? AccessToken { get; set; }
    public RefreshToken RefreshToken { get; set; }
    public AuthenticatorType RequiredAuthenticatorType { get; set; }
    public string OperatingSystem { get; set; }
    public string IPAddress { get; set; }



    public LoggedResponseDto CreateResponseDto()
    {
        return new() { AccessToken=AccessToken,RequiredAuthenticatorType=RequiredAuthenticatorType,OperatingSystem=OperatingSystem,IPAddress=IPAddress};
    }


    public class LoggedResponseDto
    {
        public AccessToken? AccessToken { get; set; }
        public AuthenticatorType RequiredAuthenticatorType { get; set; }
        public string OperatingSystem { get; set; }
        public string IPAddress { get; set; }
    }


}
