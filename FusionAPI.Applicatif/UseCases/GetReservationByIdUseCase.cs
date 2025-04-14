using FusionAPI.Applicatif.Core;
using FusionAPI.Domain.Models;
using FusionAPI.Domain.Repositories.Core;

namespace FusionAPI.Applicatif.UseCases
{
    public class GetReservationByIdUseCase : IGetReservationByIdUseCase
    {
        private readonly IReservationRepository _reservationRepository;
        public GetReservationByIdUseCase(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }
        public async Task<Reservation> ExecuteAsync(int userId, CancellationToken ct = default)
        {
            var reservation = await _reservationRepository.GetReservationByIdAsync(userId, ct);
            if (reservation == null)
                throw new InvalidOperationException("Réservation introuvable avec ces ID.");
            return reservation;
        }
    }
}