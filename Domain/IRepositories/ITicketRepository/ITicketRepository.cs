using Appliocation.DTO.TicketDTO;
using Domain.Models.Ticket;

namespace Domain.IRepositories.ITicketRepository;

public interface ITicketRepository
{
    Task AddTicket(Ticket ticket);
    Task<Ticket> GetTicket(int id);
    Task EditTicket(Ticket ticket);
    Task Save();
}