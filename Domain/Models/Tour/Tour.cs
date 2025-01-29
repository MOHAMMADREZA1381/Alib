using System.ComponentModel.DataAnnotations.Schema;
using Appliocation.DTO.TicketDTO;
using Domain.Models.Ticket.TypeOfTransportation;

namespace Domain.Models.Tour;

public class Tour
{

   
    public Tour( string des, int hotelId)
    {
        Des = des;
        HotelId = hotelId;

    }

    public int Id{ get;private set; }

    public string Des{ get; set; }

    public int HotelId{ get;private set; }

    
 
    #region Rel

    [ForeignKey("HotelId")]
    public virtual Hotel.Hotel Hotel { get; set; }


    public virtual ICollection<TourTransfer> TourTransfer { get; set; }
    #endregion

}