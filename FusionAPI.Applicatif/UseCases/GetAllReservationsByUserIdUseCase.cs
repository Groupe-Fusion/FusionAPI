using FusionAPI.Applicatif.Core;
using FusionAPI.Domain.Models;
using FusionAPI.Domain.Repositories.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FusionAPI.Applicatif.UseCases
{
    public class GetAllReservationsByUserIdUseCase : IGetAllReservationsByUserIdUseCase
    {
        private readonly IReservationRepository _reservationRepository;
        public GetAllReservationsByUserIdUseCase(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }
        public async Task<IList<Reservation>> ExecuteAsync(int userId, CancellationToken ct = default)
        {
            if (userId <= 0)
                throw new ArgumentException("L'ID de l'utilisateur doit être supérieur à zéro.", nameof(userId));
            var reservations = await _reservationRepository.GetAllReservationsByUserIdAsync(userId, ct);
            if (reservations == null || !reservations.Any())
                throw new InvalidOperationException("Aucune réservation trouvée pour cet utilisateur.");
            return reservations;
        }
    }
}
