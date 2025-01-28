using System.ComponentModel.DataAnnotations.Schema;
using Domain.Models.Locations;
using Domain.Models.Ticket;

namespace Appliocation.DTO.TicketDTO;

public class TicketLocation
{
    public TicketLocation(int id,int locationId,int ticketId,bool dstination)
    {
        Id=id;
        LocationId = locationId;
        TicketId=ticketId;
        Dstination=dstination;

    }

    public TicketLocation( int locationId, int ticketId, bool dstination)
    {
        
        LocationId = locationId;
        TicketId = ticketId;
        Dstination = dstination;

    }

    public int Id{ get;private set; }
    public int LocationId{ get;private set; }
    public int TicketId{ get;private set; }
    public bool Dstination{ get; private set; }
   

    [ForeignKey("LocationId")]
    public virtual Locations Locations { get; set; }

    [ForeignKey("TicketId")]
    public virtual Ticket Ticket{ get; set; }


}