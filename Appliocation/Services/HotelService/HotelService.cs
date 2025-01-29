using Appliocation.DTO.Hotel;
using Appliocation.IServices.IHotelService;
using Domain.IRepositories.IHotelRepository;
using Domain.Models.Hotel;

namespace Appliocation.Services.HotelService;

public class HotelService : IHotelService
{
    private readonly IHotelRepository _hotelRepository;

    public HotelService(IHotelRepository hotelRepository)
    {
        _hotelRepository = hotelRepository;
    }


    public async Task AddHotel(HotelDTO model)
    {
        var Hotel = new Hotel(model.Name, model.locationId);
        
            await _hotelRepository.AddHotel(Hotel);
        await _hotelRepository.Save();
    }

    public async Task<GetHotrlEditDTO> GetHotelById(int id)
    {
        var Hotel= await _hotelRepository.GetHotelById(id);
        var HotelDTO = new GetHotrlEditDTO()
        {
            Name = Hotel.Name,
            locationId = Hotel.LocationId,
            Id = Hotel.Id,
        };
        return HotelDTO;
    }

    public async Task EditHotel(EditHotelDTO dto)
    {
        var hotel = await _hotelRepository.GetHotelById(dto.Id);
        hotel.Name = dto.Name;
        hotel.LocationId = (int)dto.locationId;

        await _hotelRepository.EditHotel(hotel);
        await Save();
    }

    public async Task Save()
    {
        await _hotelRepository.Save();
    }
}