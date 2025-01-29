using System.ComponentModel.DataAnnotations.Schema;
using Domain.Models.Locations;
using Domain.Models.Ticket;

namespace Appliocation.DTO.TicketDTO;

public class TicketLocation
{
    public TicketLocation()
    {

    }

    public TicketLocation(int locationId, int ticketId, bool dstination)
    {

        LocationId = locationId;
        TicketId = ticketId;
        Dstination = dstination;

    }

    public int Id { get; set; }
    public int LocationId { get; set; }
    public int TicketId { get; set; }
    public bool Dstination { get; set; }


    [ForeignKey("LocationId")] public virtual Locations Locations { get; set; }

    [ForeignKey("TicketId")] public virtual Ticket Ticket { get; set; }



    public void EditTicketLocation(TicketLocation ticketLocation)
    {
        if (ticketLocation == null)
            throw new ArgumentNullException(nameof(ticketLocation));

    }


}