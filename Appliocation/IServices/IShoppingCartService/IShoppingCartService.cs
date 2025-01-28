using Appliocation.DTO.ShoppingCartDTO;
using Domain.Models.Cart;
using Domain.Models.Hotel;

namespace Appliocation.IServices.IShoppingCartService;

public interface IShoppingCartService
{
    Task AddNewOrder(int? HotelId, int? BusId,int? TourId, int UserId);
    Task<bool> AnyCart(int id); 
    Task Save();
}