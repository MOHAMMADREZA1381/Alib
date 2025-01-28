using Domain.ViewModels.User;

namespace Appliocation.IServices.IUserServices;

public interface IUserService
{
    Task<State> Register(RegisterViewModel model);
    Task<Res> Login(LoginViewModel model);
    Task<InfoForSetCokiesToLoginViewModel> GetInfoForLoginByEmail(string Email);
}