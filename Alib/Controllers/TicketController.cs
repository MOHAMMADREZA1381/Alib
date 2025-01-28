using Appliocation.DTO.TicketDTO;
using Appliocation.IServices.ITicketService;
using Domain.Models.Ticket.TypeOfTransportation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Alib.Areas.Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly ITicketService ticketService;

        public TicketController(ITicketService ticketService)
        {
            this.ticketService = ticketService;
        }


        [HttpPost("AddTicket")]
        public async Task<IActionResult> AddTicket(TicketDTO dto)
        {
            if (ModelState.IsValid)
            {
                await ticketService.AddTicket(dto);
                return Ok("Success");

            }
            return BadRequest(ModelState);
        }


        [HttpGet("GetTicket")]
        public async Task<IActionResult> GetTicket(int id)
        {
            if (id!=null)
            {
                return Ok(await ticketService.GetTicket(id));
            }
            return BadRequest(ModelState);
        }


        [HttpPut("EditTicket")]
        public async Task<IActionResult> EditTicket(EditTicketDTO dto)
        {
            if (ModelState.IsValid)
            {
                await ticketService.EditTicket(dto);
                return Ok("Success");
            }

            return BadRequest(ModelState);
        }

    }
}
