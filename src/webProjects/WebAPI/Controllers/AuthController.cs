using Application.Features.Auth.Commands.Login;
using Application.Features.Auth.Commands.Register;
using Application.Features.Auth.Dtos;
using Core.Security.Dtos;
using Core.Security.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserForRegisterDto userForRegisterDto)
        {
            RegisterCommand registerCommand = new() { UserForRegisterDto = userForRegisterDto, IPAddress = getIpAddress() };
            RegisteredDto result = await Mediator.Send(registerCommand);
            setRefreshTokenToCookie(result.RefreshToken);
            return Created("", result.AccessToken);
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserForLoginDto userForLoginDto)
        {
            string operatingSystem = GetUserOperatinSystem(HttpContext);
            LoginCommand loginCommand = new() { Email=userForLoginDto.Email,Password=userForLoginDto.Password, AuthenticatorCode = userForLoginDto.AuthenticatorCode, IPAddress = getIpAddress(), OperatingSystem = operatingSystem };
            LoggedDto result = await Mediator.Send(loginCommand);
            result.OperatingSystem=loginCommand.OperatingSystem;
            result.IPAddress = loginCommand.IPAddress;
            if (result.RefreshToken is not null) setRefreshTokenToCookie(result.RefreshToken);
            return Ok(result.CreateResponseDto());
        }


        private void setRefreshTokenToCookie(RefreshToken refreshToken)
        {
            CookieOptions cookieOptions = new() { HttpOnly = true, Expires = DateTime.UtcNow.AddDays(7) };
            Response.Cookies.Append("refreshToken", refreshToken.Token, cookieOptions);
        }


        private string GetUserOperatinSystem(HttpContext context)
        {
            string userAgent = context.Request.Headers["User-Agent"].ToString();
            if (userAgent.Contains("Windows"))
                return "Windows";
            else if (userAgent.Contains("Linux"))
                return "Linux";
            else
                return "Unknown";
        }
    }
}
