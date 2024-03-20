namespace Core.Security.Dtos;

public class UserForLoginDto
{
    public string Email { get; set; }

    public string Password { get; set; }

    public string? AuthenticatorCode { get; set; }

    public UserForLoginDto(string email, string password, string? authenticatorCode)
    {
        Email = email;
        Password = password;
        AuthenticatorCode = authenticatorCode;
    }

    public UserForLoginDto()
    {
        
    }

}
