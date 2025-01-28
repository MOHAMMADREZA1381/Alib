using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.Cart;

public class ShoppingCart
{
    public ShoppingCart(int id, int userId, bool payed)
    {
        Id = id;
        UserId = userId;
        Payed = payed;
    }

    public int Id { get; private set; }
    public int UserId { get; private set; }
    public bool Payed { get; private set; }
    #region REl
    [ForeignKey("UserId")]
    public User.User User { get; set; }
    public ICollection<ShoppingCartItem> ShoppingCartItems { get; set; }
    #endregion

}