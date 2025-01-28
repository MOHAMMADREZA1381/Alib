using Appliocation.DTO.Location;
using Appliocation.Services.LocationService;
using Domain.Models.Locations;

namespace Appliocation.IServices.ILocationService;

public interface IlocationService
{
    Task AddLocation(LocationDTO model);
    Task<ICollection<LocationDTO>> GetLocations();
    Task<GetLocationDTO> GetLocation(int id);
    Task EditLocation(EditLocationDTO model);
    Task Save();
}