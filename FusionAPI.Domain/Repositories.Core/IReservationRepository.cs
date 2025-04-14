using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FusionAPI.Domain.Models;

namespace FusionAPI.Domain.Repositories.Core
{
    public interface IReservationRepository
    {
        Task<List<Reservation>> GetAllReservationsAsync(CancellationToken ct = default);
    }
}
