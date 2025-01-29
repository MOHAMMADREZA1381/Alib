using System.ComponentModel.DataAnnotations.Schema;
using Domain.Models.Ticket.TypeOfTransportation;

namespace Domain.Models.Cart;

public class ShoppingCartItem
{
    public ShoppingCartItem()
    {
        
        
    }
    public ShoppingCartItem(int hotelid,int shoppingCartId,int ticketid,int tourid)
    {
        HotelId=hotelid;
        ShoppingCartId=shoppingCartId;
        TicketId=ticketid;
        TourId=tourid;
    }

    public int Id{ get; private set; }
    public int? HotelId{ get;private set; }
    public int ShoppingCartId{ get; private set; }
    public int? TicketId{ get; private set; }
    public int? TourId{ get; private set; }
    #region Rels
    [ForeignKey("HotelId")]
    public Hotel.Hotel? Hotel { get; set; }


    [ForeignKey("ShoppingCartId")]
    public ShoppingCart Cart{ get; set; }

    [ForeignKey("TourId")]
    public Tour.Tour? Tour{ get; set; }
    #endregion
}