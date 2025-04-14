using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FusionAPI.Domain.Models;
using FusionAPI.Domain.Repositories.Core;
using Microsoft.EntityFrameworkCore;

namespace FusionAPI.Persistence.Repositories
{
    public class ReservationRepository(
        UserManagerContext _context)
        : IReservationRepository
    {
        public Task<List<Reservation>> GetAllReservationsAsync(CancellationToken ct = default)
        {
            return _context.Reservations.ToListAsync(ct);
        }
    }
}
