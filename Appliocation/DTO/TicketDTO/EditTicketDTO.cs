using Domain.Models.Ticket;

namespace Appliocation.DTO.TicketDTO;

public class EditTicketDTO
{
    public int id{ get; set; }
    public TypeTransfer Transfer { get; set; }
    public string Details { get; set; }
    public decimal Price { get; set; }
    public int OriginId { get; set; }
    public int DstinationId { get; set; }
}