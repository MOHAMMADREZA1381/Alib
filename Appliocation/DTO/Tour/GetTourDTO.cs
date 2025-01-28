using Appliocation.DTO.TicketDTO;
using Domain.Models.Ticket;

namespace Appliocation.DTO.Tour;

public class GetTourDTO
{
    public int TourId{ get; set; }
    public string Des { get; set; }
    public int HotelId { get; set; }
    public string HotelName{ get; set; }
    public string Origin{ get; set; }
    public int Originid{ get; set; }
    public string Dstination{ get; set; }
    public int DstinationId { get; set; }
    public DateTime StartDate{ get; set; }
    public DateTime EndDate{ get; set; }
}