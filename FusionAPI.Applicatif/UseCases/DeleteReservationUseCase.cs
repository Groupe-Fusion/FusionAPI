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
            _httpClientUser = httpClientFactory.CreateClient("UserService");
        }

        public async Task<Reservation?> ExecuteAsync(int userId, CancellationToken ct = default)
        {
            var response = await _httpClientUser.GetAsync($"api/user/{userId}", ct);
            if (response.StatusCode != HttpStatusCode.OK)
                throw new ArgumentException("Book not found");

            return await _reservationRepository.DeleteReservationAsync(userId, ct);
        }
    }
}