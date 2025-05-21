using FusionAPI.Applicatif.Core;
using FusionAPI.Domain.Models;
using FusionAPI.Domain.Repositories.Core;

namespace FusionAPI.Applicatif.UseCases
{
    public class UpdateReservationUseCase
        : IUpdateReservationUseCase
    {
        private readonly IReservationRepository _reservationRepository;

        public UpdateReservationUseCase(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public async Task<Reservation> ExecuteAsync(
            int reservationId,
            Reservation newReservation, 
            CancellationToken ct = default)
        {
            newReservation.ReservationId = reservationId;
            return await _reservationRepository.UpdateReservationAsync(newReservation, ct);
        }
    }
}
