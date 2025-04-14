using FusionAPI.Domain.Models;

namespace FusionAPI.Applicatif.Core
{
    public interface IDeleteReservationUseCase
    {
        Task<Reservation?> ExecuteAsync(int userId, CancellationToken ct = default);
    }
}