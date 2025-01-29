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

    public TypeTransfer Transfer { get; set; }

    public string? Detaile { get; set; }

    public decimal Price { get; set; }

    public virtual ICollection<TicketLocation> TicketLocations { get; private set; }



    public void EditTicket(Ticket ticket)
    {
        Detaile=ticket.Detaile;
        Price=ticket.Price;
        Transfer=ticket.Transfer;
        TicketLocations=ticket.TicketLocations;
    }



}

public enum TypeTransfer
{
    Flight,
    Train,
    Bus
}