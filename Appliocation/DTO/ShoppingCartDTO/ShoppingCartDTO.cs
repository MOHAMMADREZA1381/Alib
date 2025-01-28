using Appliocation.DTO.Hotel;
using Appliocation.DTO.Tour;

namespace Appliocation.DTO.ShoppingCartDTO;

public class ShoppingCartDTO
{
    public bool Payed{ get; set; }
    public int Id{ get; set; }

 
    public List<GetHotelDTO>? HotelDtos{ get; set; }
    public List<GetTourDTO>? TourDtos{ get; set; }
}