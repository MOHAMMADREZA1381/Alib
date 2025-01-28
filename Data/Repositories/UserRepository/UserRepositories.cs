using Domain.IRepositories.IUserRepositories;
using Domain.Models.User;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories.UserRepositories;

public class UserRepositories:IUserRepository
{
    private readonly AlibContext _context;

    public UserRepositories(AlibContext context)
    {
        _context = context;
    }


    public async Task RegisterUser(User user)
    {
        await _context.AddAsync(user);
    }

    public async Task<bool> AnyUserWithEmail(string Email)
    {
        return await _context.Users.AnyAsync(a => a.Email == Email);
    }

    public async Task<User> GetUserByEmail(string Email)
    {
        var User=await _context.Users.FirstOrDefaultAsync(a => a.Email == Email);
        return User;
    }

    public async Task SaveChanges()
    {
        await _context.SaveChangesAsync();
    }
}