using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.Ticket.TypeOfTransportation;

public class TourTransfer
{
    public TourTransfer()
    {
        
    }

    public TourTransfer( int tourId, int ticketId, bool backTicket)
    {
     
        TourId = tourId;
        TicketId = ticketId;
        BackTicket = backTicket;
    }

    public int Id{ get;private set; }
    public int TourId{ get; set; }
    public int TicketId{ get; set; }
    public bool BackTicket{ get; set; }


    [ForeignKey("TicketId")]
    public virtual Ticket Ticket { get; set; }

    [ForeignKey("TourId")]
    public virtual Tour.Tour Tour{ get; set; }
}