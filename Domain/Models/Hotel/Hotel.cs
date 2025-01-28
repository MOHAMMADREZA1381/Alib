using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.PortableExecutable;
using Domain.Models.Cart;

namespace Domain.Models.Hotel;

public class Hotel
{
    public Hotel(int id,string name,int locationId)
    {
        Id=id;
        Name=name;
        LocationId = locationId;
    }

    public Hotel( string name, int locationid)
    {
        Name = name;
        LocationId = locationid;
    }

    public int Id { get;private set; }
    public string Name { get; set; }
    public int  LocationId{ get; private set; }

    #region Rels
    [ForeignKey("LocationId")]
    public Locations.Locations Locations{ get; set; }

    public ICollection<ShoppingCartItem> ShoppingCartItems{ get; set; }
    #endregion
}