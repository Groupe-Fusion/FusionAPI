using FusionAPI.Applicatif.Core;
using FusionAPI.Domain.Models;
using FusionAPI.Domain.Repositories.Core;
using System.Net;

namespace FusionAPI.Applicatif.UseCases
{
    public class DeleteReservationUseCase : IDeleteReservationUseCase
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly HttpClient _httpClientUser;

        public DeleteReservationUseCase(IReservationRepository reservationRepository, IHttpClientFactory httpClientFactory)
        {
            _reservationRepository = reservationRepository;
            //_httpClientUser = httpClientFactory.CreateClient("UserService");
        }

        public async Task<Reservation?> ExecuteAsync(int reservationId, CancellationToken ct = default)
        {
            var reservation = await _reservationRepository.GetReservationByIdAsync(reservationId, ct);
            if (reservation == null)
                throw new InvalidOperationException("Réservation introuvable avec ces ID.");

            return await _reservationRepository.DeleteReservationAsync(reservationId, ct);
        }
    }
}