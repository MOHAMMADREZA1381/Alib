using Domain.Models.Ticket;

namespace Appliocation.DTO.Tour;

public class TourDTO:EditTourDTO
{
    public string Des { get; set; }
    public int HotelId { get; set; }
    public int FirstTicket{ get; set; }
    public int SecondTicket{ get; set; }
}