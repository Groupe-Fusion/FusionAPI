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
            /*var response = await _httpClientUser.GetAsync($"api/reservations/{newReservation.ReservationId}", ct);
            if (response.StatusCode != HttpStatusCode.OK)
                throw new ArgumentException("Reservation not found");*/

            await _reservationRepository.AddReservationAsync(newReservation, ct);

            return newReservation;
        }
    }
}