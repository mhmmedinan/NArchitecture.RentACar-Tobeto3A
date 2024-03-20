namespace Core.Security.Dtos;

public class UserForRegisterDto
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public UserForRegisterDto(string email, string password, string firstName, string lastName)
    {
        Email = email;
        Password = password;
        FirstName = firstName;
        LastName = lastName;
    }

    public UserForRegisterDto()
    {
        
    }
}
