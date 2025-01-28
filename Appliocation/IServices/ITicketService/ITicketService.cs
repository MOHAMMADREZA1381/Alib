using Appliocation.DTO.TicketDTO;

namespace Appliocation.IServices.ITicketService;

public interface ITicketService
{
    Task AddTicket(TicketDTO dto);
    Task<GetTicketDTO> GetTicket(int ticketId);
    Task EditTicket(EditTicketDTO dto);
    Task Save();
}