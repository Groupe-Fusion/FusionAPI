using FusionAPI.Applicatif.Core;
using FusionAPI.Domain.Models;
using FusionAPI.Domain.Repositories.Core;

namespace FusionAPI.Applicatif.UseCases
{
    public class GetAllReservationsUseCase : IGetAllReservationsUseCase
    {
        private readonly IReservationRepository _reservationRepository;

        public GetAllReservationsUseCase(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public async Task<IList<Reservation>> ExecuteAsync(CancellationToken ct = default)
        {
            return await _reservationRepository.GetAllReservationsAsync(ct);
        }
    }
}