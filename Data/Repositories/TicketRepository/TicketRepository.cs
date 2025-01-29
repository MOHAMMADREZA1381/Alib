using Appliocation.DTO.TicketDTO;
using Domain.IRepositories.ITicketRepository;
using Domain.Models.Ticket;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories.TicketRepository;

public class TicketRepository:ITicketRepository
{
    #region Context

    

    private readonly AlibContext _context;
    private ITicketRepository _ticketRepositoryImplementation;

    public TicketRepository(AlibContext context)
    {
        _context = context;
    }
    #endregion

    public async Task AddTicket(Ticket ticket)
    {
        await _context.AddAsync(ticket);
    }

    public async Task<Ticket> GetTicket(int id)
    {
        return await _context.Tickets.Where(a => a.Id == id).Include(a=>a.TicketLocations).ThenInclude(a=>a.Locations).FirstOrDefaultAsync();
    }

    public async Task EditTicket(Ticket ticket)
    {
        _context.Update(ticket);
    }

    public async Task<List<TicketLocation>> GetTicketLocation(int id)
    {
        return await _context.TicketLocations.Where(a => a.TicketId == id).ToListAsync();
    }


    public async Task Save()
    {
       await _context.SaveChangesAsync();
    }
}