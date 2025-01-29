using Appliocation.DTO.TicketDTO;
using Appliocation.IServices.ITicketService;
using Domain.IRepositories.IlocationRepository;
using Domain.IRepositories.ITicketRepository;
using Domain.Models.Locations;
using Domain.Models.Ticket;

namespace Appliocation.Services.TicketService;

public class TicketService : ITicketService
{

    #region Repository

    private readonly ITicketRepository _repository;
    private readonly IlocationRepository _locationRepository;

    public TicketService(ITicketRepository repository, IlocationRepository locationRepository)
    {
        _repository = repository;
        _locationRepository = locationRepository;
    }

    #endregion
    public async Task AddTicket(TicketDTO dto)
    {
        var ticket = new Ticket(dto.Transfer, dto.Price, dto.Details);

        await _repository.AddTicket(ticket);
        await Save();


        var ticketOriginLocation = new TicketLocation(dto.Origin, ticket.Id, false);
        var TicketDstinationLocations = new TicketLocation(dto.Dstination, ticket.Id, true);
     

        var listLoc = new List<TicketLocation>();
        listLoc.Add(TicketDstinationLocations);
        listLoc.Add(ticketOriginLocation);

        await _locationRepository.AddListLocationForTicket(listLoc);
        await Save();


    }

    public async Task<GetTicketDTO> GetTicket(int ticketId)
    {
        var ticket = await _repository.GetTicket(ticketId);
        var TicketDTO = new GetTicketDTO()
        {
            Details = ticket.Detaile,
            Price = ticket.Price,
            Transfer = ticket.Transfer,
            Id = ticket.Id,
        };
        var listLocation = new List<TicketLocationDTO>();
        foreach (var item in ticket.TicketLocations)
        {
            var location = new TicketLocationDTO()
            {
                City = item.Locations.Name,
                Dstination = item.Dstination,
                locationId = item.LocationId
            };
            listLocation.Add(location);
        }

        TicketDTO.TicketLocationDtos = listLocation;

        return TicketDTO;

    }

    public async Task EditTicket(EditTicketDTO dto)
    {
        var Locations = await _locationRepository.GetTicketLocations(dto.id);

        var ticket = await _repository.GetTicket(dto.id);
        ticket.Detaile=dto.Details;
        ticket.Transfer=dto.Transfer;
        ticket.Price=dto.Price;

        await _repository.EditTicket(ticket);
        await Save();

        foreach (var Location in Locations)
        {
            if (Location.Dstination == false)
            {
                if (Location.LocationId != dto.OriginId)
                {
                    Location.Dstination = false;
                    Location.TicketId = ticket.Id;
                    Location.LocationId = dto.OriginId;
                    Location.Id = Location.Id;

                    await _locationRepository.EditTicketLocation(Location);
                    await Save();
                }
            }
            else if (Location.Dstination == true)
            {
                if (Location.LocationId != dto.DstinationId)
                {

                    Location.Dstination = true;
                    Location.TicketId = ticket.Id;
                    Location.LocationId = dto.DstinationId;
                    Location.Id = Location.Id;

                    await _locationRepository.EditTicketLocation(Location);
                    await Save();
                }
            }
        }

    }

    public async Task Save()
    {
        await _repository.Save();
    }
}