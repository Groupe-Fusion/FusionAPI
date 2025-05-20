using FusionAPI.Domain.Models;
using FusionAPI.Domain.Repositories.Core;
using Microsoft.EntityFrameworkCore;

namespace FusionAPI.Persistence.Repositories
{
    public class PaymentRepository(PaymentManagerContext _context) : IPaymentRepository
    {
        public Task<Payment?> GetPaymentByIdAsync(int paymentId, CancellationToken ct = default)
        {
            return _context.Payments
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.PaymentId == paymentId, ct);
        }

        public Task<bool> DeletePaymentByIdAsync(int paymentId, CancellationToken ct = default)
        {
            var payment = _context.Payments.Find(paymentId);
            if (payment == null) return Task.FromResult(false);
            _context.Payments.Remove(payment);
            return _context.SaveChangesAsync(ct).ContinueWith(t => t.Result > 0, ct);
        }

        public Task<Payment> AddPaymentAsync(Payment payment, CancellationToken ct = default)
        {
            _context.Payments.Add(payment);
            return _context.SaveChangesAsync(ct).ContinueWith(t => payment, ct);
        }

        public Task<List<Payment>> GetAllPaymentsAsync(CancellationToken ct = default)
        {
            return _context.Payments
                .ToListAsync(ct);
        }
    }
}
