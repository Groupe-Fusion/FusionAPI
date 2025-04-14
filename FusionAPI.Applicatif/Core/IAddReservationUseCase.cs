using FusionAPI.Domain.Models;

namespace FusionAPI.Applicatif.Core
{
    public interface IAddReservationUseCase
    {
        Task<Reservation> ExecuteAsync(Reservation newReservation, CancellationToken ct = default);
    }
}