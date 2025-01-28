using Appliocation.DTO.Hotel;
using Appliocation.IServices.IHotelService;
using Appliocation.IServices.ILocationService;
using Domain.Models.Hotel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Alib.Areas.Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IHotelService _hotelService;
        private readonly IlocationService _locationService;

        public HotelController(IHotelService hotelService, IlocationService locationService)
        {
            _hotelService = hotelService;
            _locationService = locationService;
        }


        [HttpPost("AddHotel")]
        public async Task<IActionResult> AddHotel(HotelDTO model)
        {
            if (ModelState.IsValid)
            {
                await _hotelService.AddHotel(model);
               return Ok("Success");
            }

            return BadRequest("Failed");
        }

        [HttpGet("GetHotelById")]
        public async Task<IActionResult> GetHotelById(int id)
        {
            if (id!=null)
            {
                var Hotel=await _hotelService.GetHotelById(id);
                return Ok(Hotel);
            }

            return BadRequest();
        }


        [HttpPut("EditHotel")]
        public async Task<IActionResult> EditHotel(EditHotelDTO dto)
        {
            if (ModelState.IsValid)
            {
                await _hotelService.EditHotel(dto);
                return Ok("Success");
            }

            return BadRequest();
        }
    }
}
