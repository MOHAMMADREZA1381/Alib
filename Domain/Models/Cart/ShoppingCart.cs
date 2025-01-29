using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.Cart;

public class ShoppingCart
{
    public ShoppingCart()
    {

    }
    public ShoppingCart(int userId, bool payed)
    {

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



    public void AddItem(ShoppingCartItem item)
    {
        if (item == null) throw new ArgumentNullException(nameof(item));

        ShoppingCartItems.Add(item);
    }

    public void RemoveItem(ShoppingCartItem item)
    {
        if (item == null)
            throw new ArgumentNullException(nameof(item));
        ShoppingCartItems.Remove(item);
    }

    public void MarkAsPayed()
    {
        Payed = true;
    }



}