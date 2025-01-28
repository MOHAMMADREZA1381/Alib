using Domain.Models.Cart;
using Domain.Models.Ticket.TypeOfTransportation;

namespace Domain.IRepositories.IShoppingCartRepository;

public interface IShoppingCartRepository
{
    Task AddAnOrderToCart(ShoppingCart cart);
    Task<bool> UserHaveAnyActiveShoppingCart(int userid);
    Task CreateShoppingCart(ShoppingCart cart);
    Task<ShoppingCart> GetShoppingCartById(int id);
    Task AddShoppingCartItem(ShoppingCartItem shoppingCartItem);
    Task Save();
}