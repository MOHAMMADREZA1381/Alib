using Domain.IRepositories.IHotelRepository;
using Domain.Models.Hotel;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories.HotelRepository;

public class HotelRepository:IHotelRepository 
{
    private readonly AlibContext _context;

    public HotelRepository(AlibContext context)
    {
        _context = context;
    }

    public async Task AddHotel(Hotel hotel)
    {
        await _context.AddAsync(hotel);
    }

    public async Task<Hotel> GetHotelById(int id)
    {
        return await _context.Hotels.Where(a => a.Id == id).FirstOrDefaultAsync();
    }

    public async Task EditHotel(Hotel hotel)
    {
         _context.Update(hotel);
    }

    public async Task Save()
    {
        await _context.SaveChangesAsync();
    }
}