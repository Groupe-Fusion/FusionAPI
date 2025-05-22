using FusionAPI.Domain.Models;

namespace FusionAPI.Domain.Repositories.Core
{
    public interface IReservationRepository
    {
        Task<List<Reservation>> GetAllReservationsAsync(CancellationToken ct = default);
        Task<Reservation?> GetReservationByIdAsync(int reservationId, CancellationToken ct = default);
        Task<Reservation> AddReservationAsync(Reservation reservation, CancellationToken ct = default);
        Task<Reservation> UpdateReservationAsync(Reservation reservation, CancellationToken ct = default);
        Task<Reservation> DeleteReservationAsync(int reservationId, CancellationToken ct = default);

        Task<List<Reservation?>> GetAllReservationsByUserIdAsync(int userId, CancellationToken ct = default);
    }
}
