using Appliocation.IServices.IUserServices;
using Domain.IRepositories.IUserRepositories;
using Domain.Models.User;
using Domain.ViewModels.User;

namespace Appliocation.Services.UserServices;

public class UserService : IUserService
{
    #region Repo



    private readonly IUserRepository _userRepositories;

    public UserService(IUserRepository userRepositories)
    {
        _userRepositories = userRepositories;
    }
    #endregion

    public async Task<State> Register(RegisterViewModel model)
    {

        bool IsAnyUser = await _userRepositories.AnyUserWithEmail(model.Email);
        if (IsAnyUser)
        {
            return State.UserAlreadyRegistered;
        }

        if (model.Password != model.Password)
        {
            return State.WrongPassword;
        }

        var User = new User(model.Email, PasswordHelper.HashPassword.HasPassword(model.Password), false);
      
        await _userRepositories.RegisterUser(User);
        await _userRepositories.SaveChanges();
        return State.Succeeded;
    }

    public async Task<Res> Login(LoginViewModel viewModel)
    {
        var Password = PasswordHelper.HashPassword.HasPassword(viewModel.Passdword);
        var User = await _userRepositories.GetUserByEmail(viewModel.Email);
        if (User == null) return Res.Failde;
        if (User.Password != Password) return Res.Failde;
        return Res.Success;
    }

    public async Task<InfoForSetCokiesToLoginViewModel> GetInfoForLoginByEmail(string Email)
    {
        var user=await _userRepositories.GetUserByEmail(Email);
        var Info = new InfoForSetCokiesToLoginViewModel()
        {
            Email = user.Email,
            id = user.Id
        };
        return Info;
    }
}