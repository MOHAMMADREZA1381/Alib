﻿using Appliocation.DTO.TicketDTO;
using Appliocation.DTO.Tour;
using Appliocation.IServices.ITourService;
using Domain.IRepositories.ITourRepository;
using Domain.Models.Ticket.TypeOfTransportation;
using Domain.Models.Tour;

namespace Appliocation.Services.TourService;

public class TourService : ITourService
{
    private readonly ITourRepository _repository;

    public TourService(ITourRepository repository)
    {
        _repository = repository;
    }

    public async Task AddTour(TourDTO model)
    {
        var Tour = new Tour(model.Des, model.HotelId);
        await _repository.AddTour(Tour);
        await Save();

        var TourTransfers = new List<TourTransfer>();


        var TicketFirst = new TourTransfer(Tour.Id, model.FirstTicket, false);

        var TicketSecond = new TourTransfer(Tour.Id, model.SecondTicket, true);
     
        TourTransfers.Add(TicketFirst);
        TourTransfers.Add(TicketSecond);
        await _repository.AddTourTransfer(TourTransfers);
        await Save();
    }

    public async Task<GetTourDTO> GetTour(int id)
    {
        var tour = await _repository.GetTourById(id);
        var DTO = new GetTourDTO()
        {
            HotelId = tour.HotelId,
            TourId = tour.Id,
            Des = tour.Des,
            HotelName = tour.Hotel.Name,

        };

        foreach (var item in tour.TourTransfer)
        {
            foreach (var location in item.Ticket.TicketLocations)
            {
                if (item.BackTicket == false)
                {
                    DTO.Origin = location.Locations.Name;
                    DTO.Originid = location.LocationId;
                }
                else
                {
                    DTO.DstinationId = location.LocationId;
                    DTO.Dstination = location.Locations.Name;
                }
            }
        }

        return DTO;
    }

    public async Task EditTour(TourDTO model)
    {


        var TourTansfer = await _repository.GetTourTransferById(model.id);

        var EditTour = await _repository.GetTourById(model.id);
        EditTour.Des = model.Des;
        EditTour.HotelId= model.HotelId;

        await _repository.EditTour(EditTour);
        await Save();

        foreach (var item in TourTansfer)
        {

            if (item.BackTicket == true)
            {
                if (item.TicketId != model.SecondTicket)
                {
                    item.TicketId = model.SecondTicket;
                    item.TourId=model.id;
                    item.BackTicket = true;

                    await _repository.EditTourTransfer(item);
                    await Save();
                }
            }
            else if (item.BackTicket == false)
            {
                if (item.TicketId != model.FirstTicket)
                {
                    item.TicketId = model.FirstTicket;
                    item.TourId = model.id;
                    item.BackTicket = false;

                    await _repository.EditTourTransfer(item);
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