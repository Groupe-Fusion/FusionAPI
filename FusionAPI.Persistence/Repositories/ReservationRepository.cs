using FusionAPI.Domain.Models;
using FusionAPI.Domain.Repositories.Core;
using Microsoft.EntityFrameworkCore;

namespace FusionAPI.Persistence.Repositories
{
    public class ReservationRepository(
        UserManagerContext _context)
        : IReservationRepository
    {
        public async Task<Reservation> AddReservationAsync(Reservation reservation, CancellationToken ct = default)
        {
            var user = await _context.Users.FindAsync(new object[] { reservation.UserId }, ct);
            if (user is null)
                throw new ArgumentException("user not found");

            _context.Reservations.Add(reservation);
            await _context.SaveChangesAsync(ct);
            return reservation;
        }

        public async Task<Reservation> DeleteReservationAsync(int reservationId, CancellationToken ct = default)
        {
            var reservation = await GetReservationByIdAsync(reservationId, ct);
            if (reservation is null)
                throw new ArgumentNullException("No reservation found with these id");

            _context.Reservations.Remove(reservation);
            await _context.SaveChangesAsync(ct);
            return reservation;
        }

        public Task<List<Reservation>> GetAllReservationsAsync(CancellationToken ct = default)
        {
            return _context.Reservations.ToListAsync(ct);
        }

        //TODO modifs
        public Task<Reservation?> GetReservationByIdAsync(int reservationId, CancellationToken ct = default)
        {
            return _context.Reservations
                .FirstOrDefaultAsync(r => r.ReservationId == reservationId, ct);
        }

        public async Task<Reservation> UpdateReservationAsync(Reservation reservation, CancellationToken ct = default)
        {
            _context.Reservations.Update(reservation);
            await _context.SaveChangesAsync(ct);
            return reservation;
        }
    }
}