using FusionAPI.Domain.Models;

namespace FusionAPI.Applicatif.Core
{
    public interface IUpdateReservationUseCase
    {
        Task<Reservation> ExecuteAsync(int reservationId, Reservation newReservation, CancellationToken ct = default);
    }
}
