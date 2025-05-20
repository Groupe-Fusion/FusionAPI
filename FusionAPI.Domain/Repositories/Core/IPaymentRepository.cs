using FusionAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FusionAPI.Domain.Repositories.Core
{
    public interface IPaymentRepository
    {
        Task<List<Payment>> GetAllPaymentsAsync(CancellationToken ct = default);
        Task<Payment?> GetPaymentByIdAsync(int paymentId, CancellationToken ct = default);
        Task<Payment> AddPaymentAsync(Payment payment, CancellationToken ct = default);
        Task<bool> DeletePaymentByIdAsync(int paymentId, CancellationToken ct = default);
    }
}
