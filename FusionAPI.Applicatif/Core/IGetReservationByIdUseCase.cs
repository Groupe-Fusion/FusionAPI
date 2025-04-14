using FusionAPI.Domain.Models;

namespace FusionAPI.Applicatif.Core
{
    public interface IGetReservationByIdUseCase
    {
        Task<Reservation> ExecuteAsync(int userId, CancellationToken ct = default);
    }
}