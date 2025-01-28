using Appliocation.DTO.Tour;
using Appliocation.IServices.ITourService;
using Domain.Models.Tour;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Alib.Areas.Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TourController : ControllerBase
    {
        private readonly ITourService _tourService;

        public TourController(ITourService tourService)
        {
            _tourService = tourService;
        }

        [HttpPost("AddTour")]
        public async Task<IActionResult> AddNewTour(TourDTO model)
        {
            if (ModelState.IsValid)
            {
                await _tourService.AddTour(model);
                return Ok("Added");
            }

            return Ok("Error");
        }


        [HttpGet("GetTour")]
        public async Task<IActionResult> GetTour(int id)
        {
            if (id!=null)
            {
                return Ok(await _tourService.GetTour(id));
            }

            return BadRequest();
        }


        [HttpPut("EditTour")]
        public async Task<IActionResult> EditTour(TourDTO dto)
        {
            if (ModelState.IsValid)
            {

                await _tourService.EditTour(dto);
               return Ok("Success");
            }

            return BadRequest();
        }

    }
}
