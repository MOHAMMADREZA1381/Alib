namespace Appliocation.DTO.TicketDTO;

public class TicketLocationDTO:TicketTypeTransferDTO
{

    public int locationId { get; set; }
    public int TicketId { get; set; }
    public bool Dstination { get; set; }
    public string City{ get; set; }
}