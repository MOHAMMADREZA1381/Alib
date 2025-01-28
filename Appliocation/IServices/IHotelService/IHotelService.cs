using Appliocation.DTO.Hotel;
using Domain.Models.Hotel;

namespace Appliocation.IServices.IHotelService;

public interface IHotelService
{
    Task AddHotel(HotelDTO model);
    Task<GetHotrlEditDTO> GetHotelById(int id);
    Task EditHotel(EditHotelDTO dto);
    Task Save();
}