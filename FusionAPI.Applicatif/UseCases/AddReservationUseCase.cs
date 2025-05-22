using FusionAPI.Applicatif.Core;
using FusionAPI.Domain.Models;
using FusionAPI.Domain.Repositories.Core;
using System.Net;

namespace FusionAPI.Applicatif.UseCases
{
    public class AddReservationUseCase : IAddReservationUseCase
    {
        private readonly IReservationRepository _reservationRepository;

        public AddReservationUseCase(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public async Task<Reservation> ExecuteAsync(Reservation newReservation, CancellationToken ct = default)
        {
            await _reservationRepository.AddReservationAsync(newReservation, ct);

            return newReservation;
        }
    }
}