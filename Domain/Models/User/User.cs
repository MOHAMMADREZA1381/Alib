using System.ComponentModel.DataAnnotations;
using Domain.Models.Cart;

namespace Domain.Models.User;

public class User
{

    public User(int id,string email,string password,bool isActive)
    {
        Id=id;
        Email=email;
        Password=password;
        IsActive=isActive;
    }
    public User(string email, string password, bool isActive)
    {
        Email = email;
        Password = password;
        IsActive = isActive;
    }


    [Key]
    public int Id { get;private set; }
    [EmailAddress(ErrorMessage = "Email is not valid")]
    [Required(ErrorMessage = "Enter your email")]
    public string Email { get; set; }
    public string? PhoneNumber  { get; set; }
    public string Password { get;private set; }
    public long? NationalCode { get; set; }
    public bool IsActive { get;private set; }

    public ICollection<ShoppingCart> Carts{ get; set; }
}