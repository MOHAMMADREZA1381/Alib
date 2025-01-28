using Appliocation.IServices.IShoppingCartService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Alib.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {

        private readonly IShoppingCartService _shoppingCartService;

        public ShoppingCartController(IShoppingCartService shoppingCartService)
        {
            _shoppingCartService = shoppingCartService;
        }


        [Authorize]
        [HttpGet("CartDetails")]
        public async Task<IActionResult> CardDetails()
        {
            var UserId = int.Parse(User.Claims.FirstOrDefault().Value);
            bool AnyCart = await _shoppingCartService.AnyCart(UserId);
            if (AnyCart==true)
            {
            return Ok();
            }

            return NotFound("No Active Cart");
        }


        [Authorize]
        [HttpPost("AddToCart")]
        public async Task<IActionResult> AddToShoppingCart(int? HotelId,int? BusId,int? TourId)
        {
            var UserId = int.Parse(User.Claims.FirstOrDefault().Value);
            if (HotelId!=null || BusId!=null || TourId!=null)
            {
                await _shoppingCartService.AddNewOrder(HotelId,BusId,TourId,UserId);
                return Ok("Aded");
            }

            return NotFound("something bad happend");
        }



    }
}
