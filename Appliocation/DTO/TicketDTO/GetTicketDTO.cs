using Domain.Models.Ticket;

namespace Appliocation.DTO.TicketDTO;

public class GetTicketDTO
{
    public int Id{ get; set; }
    public TypeTransfer Transfer { get; set; }
    public string Details { get; set; }
    public decimal Price { get; set; }
    public ICollection<TicketLocationDTO> TicketLocationDtos{ get; set; }

}