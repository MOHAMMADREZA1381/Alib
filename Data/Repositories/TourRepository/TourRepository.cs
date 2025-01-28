using Domain.IRepositories.ITourRepository;
using Domain.Models.Ticket.TypeOfTransportation;
using Domain.Models.Tour;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories.TourRepository;

public class TourRepository:ITourRepository
{
    private readonly AlibContext _context;

    public TourRepository(AlibContext context)
    {
        _context = context;
    }

    public async Task AddTour(Tour tour)
    {
        await _context.Tours.AddAsync(tour);
    }

    public async Task EditTour(Tour tour)
    {
         _context.Update(tour);
    }

    public async Task<Tour> GetTourById(int id)
    {
        return await _context.Tours.Where(a => a.Id == id).Include(a=>a.Hotel).Include(a=>a.TourTransfer).ThenInclude(a=>a.Ticket).ThenInclude(a=>a.TicketLocations).ThenInclude(a=>a.Locations).FirstOrDefaultAsync();
    }

    public async Task AddTourTransfer(List<TourTransfer> tourTransfer)
    {
        await _context.AddRangeAsync(tourTransfer);
    }

    public async Task<List<TourTransfer>> GetTourTransferById(int id)
    {
        return await _context.TourTransfers.Where(a => a.TourId == id).ToListAsync();
    }

    public async Task AddTourTransfer(TourTransfer tourTransfer)
    {
       await _context.AddAsync(tourTransfer);
    }

    public async Task DeleteTourTransfer(TourTransfer tourTransfer)
    {
         _context.Remove(tourTransfer);
    }

    public async Task EditTourTransfer(TourTransfer tourTransfer)
    {
        _context.Update(tourTransfer);
    }

    public async Task Save()
    {
       await _context.SaveChangesAsync();
    }
}