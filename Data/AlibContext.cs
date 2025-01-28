using Appliocation.DTO.TicketDTO;
using Domain.Models.Cart;
using Domain.Models.Hotel;
using Domain.Models.Locations;
using Domain.Models.Ticket;
using Domain.Models.Ticket.TypeOfTransportation;
using Domain.Models.Tour;
using Domain.Models.User;
using Microsoft.EntityFrameworkCore;

namespace Data;

public class AlibContext : DbContext
{
    public AlibContext(DbContextOptions<AlibContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
        {
            relationship.DeleteBehavior = DeleteBehavior.Restrict;
        }
    }



    public DbSet<User> Users { get; set; }
    public DbSet<ShoppingCart> ShoppingCarts { get; set; }
    public DbSet<Locations> LocationsList { get; set; }
    public DbSet<Hotel> Hotels { get; set; }
    public DbSet<ShoppingCartItem> ShoppingCartItems{ get; set; }
    public DbSet<Tour> Tours{ get; set; }
    public DbSet<TourTransfer> TourTransfers{ get; set; }
    public DbSet<TicketLocation> TicketLocations{ get; set; }
    public DbSet<Ticket> Tickets{ get; set; }
}