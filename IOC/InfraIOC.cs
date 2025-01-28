using Appliocation.IServices.IHotelService;
using Appliocation.IServices.ILocationService;
using Appliocation.IServices.IShoppingCartService;
using Appliocation.IServices.ITicketService;
using Appliocation.IServices.ITourService;
using Appliocation.IServices.IUserServices;
using Appliocation.Services.HotelService;
using Appliocation.Services.LocationService;
using Appliocation.Services.ShoppingService;
using Appliocation.Services.TicketService;
using Appliocation.Services.TourService;
using Appliocation.Services.UserServices;
using Data.Repositories.HotelRepository;
using Data.Repositories.LocatioRepository;
using Data.Repositories.ShoppingCartRepository;
using Data.Repositories.TicketRepository;
using Data.Repositories.TourRepository;
using Data.Repositories.UserRepositories;
using Domain.IRepositories.IHotelRepository;
using Domain.IRepositories.IlocationRepository;
using Domain.IRepositories.IShoppingCartRepository;
using Domain.IRepositories.ITicketRepository;
using Domain.IRepositories.ITourRepository;
using Domain.IRepositories.IUserRepositories;
using Microsoft.Extensions.DependencyInjection;

namespace IOC;

public class InfraIOC
{
    public static void RegisterServices(IServiceCollection services)
    {

        services.AddScoped<IUserRepository, UserRepositories>();
        services.AddScoped<IlocationRepository, LocationRepository>();
        services.AddScoped<IHotelRepository, HotelRepository>();
        services.AddScoped<IShoppingCartRepository, ShoppingCartRepository>();
        services.AddScoped<ITourRepository, TourRepository>();
        services.AddScoped<ITicketRepository, TicketRepository>();







        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IlocationService, LocationService>();
        services.AddScoped<IHotelService, HotelService>();
        services.AddScoped<IShoppingCartService, ShoppingCartService>();
        services.AddScoped<ITourService, TourService>();
        services.AddScoped<ITicketService, TicketService>();



    }
}