using Domain.Models.Ticket;

namespace Appliocation.DTO.TicketDTO;

public class TicketDTO
{
    public TypeTransfer Transfer { get; set; }
    public string Details { get; set; }
    public decimal Price { get; set; }
    public int Origin{ get; set; }
    public int Dstination{ get; set; }
}