using Appliocation.DTO.Location;
using Appliocation.IServices.ILocationService;
using Domain.Models.Locations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Alib.Areas.Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly IlocationService _locationService;

        public LocationController(IlocationService locationService)
        {
            _locationService = locationService;
        }

        [HttpGet("AllLocations")]
        public async Task<IActionResult> GetAllLocations()
        {

            var list = await _locationService.GetLocations();
            return Ok(list);
        }


        [HttpPost("AddLocation")]
        public async Task<IActionResult> AddLocation(LocationDTO model)
        {
            if (ModelState.IsValid)
            {
                await _locationService.AddLocation(model);
                return Ok("Success");
            }
            return BadRequest(ModelState);

        }


        [HttpGet("GetLocation")]
        public async Task<IActionResult> GetLocationById(int id)
        {
            if (id!=null)
            {
                return Ok(await _locationService.GetLocation(id));
            }
            return BadRequest();
        }


        [HttpPut("EditPut")]
        public async Task<IActionResult> EditLocation(EditLocationDTO dto)
        {
            if (ModelState.IsValid)
            {
                await _locationService.EditLocation(dto);
                return Ok("Success");
            }
            return BadRequest();
        }
    }
}
