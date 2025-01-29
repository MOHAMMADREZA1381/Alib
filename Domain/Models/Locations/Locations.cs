using Domain.Models.Ticket.TypeOfTransportation;

namespace Domain.Models.Locations;

public class Locations
{
    public Locations(string name, bool international)
    {
        Name=name;
        International=international;
    }

  

    public int Id { get; private set; }
    public string Name { get; set; }
    public bool International { get; set; }

    #region Rels


    public ICollection<Hotel.Hotel> Hotels { get; set; }

    #endregion
}