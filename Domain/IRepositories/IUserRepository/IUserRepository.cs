using Domain.Models.User;

namespace Domain.IRepositories.IUserRepositories;

public interface IUserRepository
{
    Task RegisterUser(User user);
    Task<bool> AnyUserWithEmail(string Email);
    Task<User> GetUserByEmail(string Email);
    Task SaveChanges();
}