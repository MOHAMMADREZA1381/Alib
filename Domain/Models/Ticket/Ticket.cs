using System.ComponentModel.DataAnnotations.Schema;
using Appliocation.DTO.TicketDTO;

namespace Domain.Models.Ticket;

public class Ticket
{
    public Ticket()
    {
        
    }

    public Ticket( TypeTransfer transfer, decimal price, string? detail)
    {
        Transfer = transfer;
        Price = price;
        Detaile = detail;
        TicketLocations = new List<TicketLocation>();
    }

    public int Id { get; private set; }

    public TypeTransfer Transfer { get; private set; }

    public string? Detaile { get; set; }

    public decimal Price { get; private set; }

    public virtual ICollection<TicketLocation> TicketLocations { get; private set; }


}

public enum TypeTransfer
{
    Flight,
    Train,
    Bus
}