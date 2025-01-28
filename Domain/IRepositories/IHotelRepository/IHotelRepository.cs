using Domain.Models.Hotel;

namespace Domain.IRepositories.IHotelRepository;

public interface IHotelRepository
{
    Task AddHotel(Hotel hotel);
    Task<Hotel> GetHotelById(int id);
    Task EditHotel(Hotel hotel);
    Task Save();
}