using FusionAPI.Domain.Models;

namespace FusionAPI.Applicatif.Core
{
    public interface IGetAllReservationsUseCase
    {
        Task<IList<Reservation>> ExecuteAsync(CancellationToken ct = default);
    }
}