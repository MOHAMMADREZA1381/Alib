
using Appliocation.DTO.Tour;
using Domain.Models.Tour;

namespace Appliocation.IServices.ITourService;

public interface ITourService
{
    Task AddTour(TourDTO model);
    Task<GetTourDTO> GetTour(int id);
    Task EditTour(TourDTO dto);
    Task Save();
}