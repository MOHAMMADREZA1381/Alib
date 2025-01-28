using Appliocation.DTO.TicketDTO;
using Domain.Models.Locations;

namespace Domain.IRepositories.IlocationRepository;

public interface IlocationRepository
{
    Task AddNewLocation(Locations locations);
    Task<List<Locations>> GetAllLocations();
    Task EditLocation(Locations locations);
    Task<Locations> GetLocationById(int id);
    Task AddListLocationForTicket(ICollection<TicketLocation> ticketLocations);
    Task<List<TicketLocation>> GetTicketLocations(int TicketId);
    Task DeleteTicketLocation(TicketLocation location);
    Task EditTicketLocation(TicketLocation location);
    Task Save();
}