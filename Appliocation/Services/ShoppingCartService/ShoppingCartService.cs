using System.Security.AccessControl;
using Appliocation.DTO.Hotel;
using Appliocation.DTO.ShoppingCartDTO;
using Appliocation.DTO.Tour;
using Appliocation.IServices.IHotelService;
using Appliocation.IServices.IShoppingCartService;
using Domain.IRepositories.IShoppingCartRepository;
using Domain.Models.Cart;
using Domain.Models.Hotel;
using Domain.Models.Ticket.TypeOfTransportation;
using Domain.Models.Tour;


namespace Appliocation.Services.ShoppingService;

public class ShoppingCartService : IShoppingCartService
{
    private readonly IHotelService _hotelService;
    private readonly IShoppingCartRepository _shoppingCartService;

    public ShoppingCartService(IHotelService hotelService, IShoppingCartRepository shoppingCartService)
    {
        _hotelService = hotelService;
        _shoppingCartService = shoppingCartService;
    }

    public async Task AddNewOrder(int? HotelId, int? BusId, int? TourId, int UserId)
    {
        bool UserHaveAnyCart = await _shoppingCartService.UserHaveAnyActiveShoppingCart(UserId);

    }

  
    public async Task<bool> AnyCart(int id)
    {
        return await _shoppingCartService.UserHaveAnyActiveShoppingCart(id);
    }

    public async Task Save()
    {
        await _shoppingCartService.Save();
    }
}