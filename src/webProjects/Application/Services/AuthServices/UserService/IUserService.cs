using Core.Security.Entities;

namespace Application.Services.AuthServices.UserService;

public interface IUserService
{
    public Task<User?> GetByEmail(string email);
    public Task<User> GetById(Guid id);
    public Task<User> Update(User user);
}
