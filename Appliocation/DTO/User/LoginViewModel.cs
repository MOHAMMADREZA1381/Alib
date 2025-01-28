using System.ComponentModel.DataAnnotations;

namespace Domain.ViewModels.User;

public class LoginViewModel
{
    [EmailAddress]
    public string Email { get; set; }
    public string Passdword { get; set; }
}

public enum Res
{
    Success,
    Failde,
    WrongPass
}