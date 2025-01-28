using Domain.Models.Ticket.TypeOfTransportation;
using Domain.Models.Tour;

namespace Domain.IRepositories.ITourRepository;

public interface ITourRepository
{
    Task AddTour(Tour tour);
    Task EditTour(Tour tour);
    Task<Tour> GetTourById(int id);
    Task AddTourTransfer(List<TourTransfer> tourTransfer);
    Task<List<TourTransfer>> GetTourTransferById(int id);
    Task AddTourTransfer(TourTransfer tourTransfer);
    Task DeleteTourTransfer(TourTransfer tourTransfer);
    Task EditTourTransfer(TourTransfer tourTransfer);
    Task Save();

}