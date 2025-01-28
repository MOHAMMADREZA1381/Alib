using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace Domain.ViewModels.User;

public class RegisterViewModel
{
    [EmailAddress(ErrorMessage = "Email is not valid")]
    [Required(ErrorMessage = "Enter your email")]
    public string Email { get; set; }
    public string Password { get; set; }
    [Compare("Password",ErrorMessage = "Passwords not Same ")]
    public string ConfirmPassword { get; set; }
    public long? NationalCode { get; set; }
    public bool IsEmailConfirmed = true;



}

public enum State
{
    Succeeded,
    UserAlreadyRegistered,
    WrongPassword,
    Failed


}