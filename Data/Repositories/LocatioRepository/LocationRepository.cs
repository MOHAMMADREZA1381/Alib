using Appliocation.DTO.TicketDTO;
using Domain.IRepositories.IlocationRepository;
using Domain.Models.Locations;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories.LocatioRepository;

public class LocationRepository:IlocationRepository
{
    private readonly AlibContext _context;

    public LocationRepository(AlibContext context)
    {
        _context = context;
    }


    public async Task AddNewLocation(Locations locations)
    {
        await _context.AddAsync(locations);
    }

    public async Task<List<Locations>> GetAllLocations()
    {
        return await _context.LocationsList.ToListAsync();
    }

    public async Task EditLocation(Locations locations)
    {
         _context.Update(locations);
    }

    public async Task<Locations> GetLocationById(int id)
    {
        return await _context.LocationsList.Where(a => a.Id == id).FirstOrDefaultAsync();
    }

    public async Task AddListLocationForTicket(ICollection<TicketLocation> ticketLocations)
    {
        await _context.AddRangeAsync(ticketLocations);
    }

    public async Task<List<TicketLocation>> GetTicketLocations(int TicketId)
    {
        return await _context.TicketLocations.Where(a => a.TicketId == TicketId).ToListAsync();
    }

    public async Task DeleteTicketLocation(TicketLocation location)
    {
        _context.Remove(location);
    }

    public async Task EditTicketLocation(TicketLocation location)
    {
        _context.Update(location);
    }


    public async Task Save()
    {
        await _context.SaveChangesAsync();
    }
}