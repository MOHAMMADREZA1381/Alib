using Appliocation.DTO.Location;
using Appliocation.IServices.ILocationService;
using Domain.IRepositories.IlocationRepository;
using Domain.Models.Locations;

namespace Appliocation.Services.LocationService;

public class LocationService:IlocationService
{

    private readonly IlocationRepository _locationService;

    public LocationService(IlocationRepository locationService)
    {
        _locationService = locationService;
    }

    public async Task AddLocation(LocationDTO model)
    {
        var Loc = new Locations(model.Name, model.International);
      
        await _locationService.AddNewLocation(Loc);
        await _locationService.Save();
    }

    public async Task<ICollection<LocationDTO>> GetLocations()
    {
        var locations = await _locationService.GetAllLocations();
        var list = new List<LocationDTO>();
        foreach (var item in locations)
        {
            var ViewModel=new LocationDTO()
            {
                Name = item.Name,
                id = item.Id,
                International = item.International,
            };
            list.Add(ViewModel);
        }
        return list;
    }

    public async Task<GetLocationDTO> GetLocation(int id)
    {
        var location = await _locationService.GetLocationById(id);
        var locationDTO = new GetLocationDTO()
        {
            id = location.Id,
            International = location.International,
            Name = location.Name,
        };
        return locationDTO;
    }

    public async Task EditLocation(EditLocationDTO model)
    {
        var Location = await _locationService.GetLocationById(model.id);
        Location.Name=model.Name;
        Location.International = model.International;
        await _locationService.EditLocation(Location);
        await Save();
    }

    public async Task Save()
    {
        await _locationService.Save();
    }
}