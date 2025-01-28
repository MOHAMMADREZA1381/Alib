using Domain.IRepositories.IShoppingCartRepository;
using Domain.Models.Cart;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories.ShoppingCartRepository;

public class ShoppingCartRepository : IShoppingCartRepository
{
    private readonly AlibContext _context;
    public ShoppingCartRepository(AlibContext context)
    {
        _context = context;
    }




    public async Task AddAnOrderToCart(ShoppingCart cart)
    {
        _context.ShoppingCarts.Update(cart);
    }

    public async Task<bool> UserHaveAnyActiveShoppingCart(int userid)
    {
        return await _context.ShoppingCarts.AnyAsync(a => a.UserId == userid && a.Payed == false);
    }

    public async Task CreateShoppingCart(ShoppingCart cart)
    {
        await _context.AddAsync(cart);
    }

    public async Task<ShoppingCart> GetShoppingCartById(int id)
    {
        return await _context.ShoppingCarts.Where(a => a.UserId == id).FirstOrDefaultAsync();
    }

  

    public async Task AddShoppingCartItem(ShoppingCartItem shoppingCartItem)
    {
        await _context.AddAsync(shoppingCartItem);
    }

    public async Task Save()
    {
        await _context.SaveChangesAsync();
    }
}