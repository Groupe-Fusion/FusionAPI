using FusionAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace FusionAPI.Persistence.Repositories
{
    public class PaymentRepository(PaymentManagerContext _context)
    {
        public Task<Payment?> GetByIdAsync(int paymentId, CancellationToken ct = default)
        {
            return _context.Payments
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.PaymentId == paymentId, ct);
        }
        public Task<List<Payment>> GetAllAsync(CancellationToken ct = default)
        {
            return _context.Payments
                .ToListAsync(ct);
        }
        public Task<bool> DeleteByIdAsync(int paymentId, CancellationToken ct = default)
        {
            var payment = _context.Payments.Find(paymentId);
            if (payment == null) return Task.FromResult(false);
            _context.Payments.Remove(payment);
            return _context.SaveChangesAsync(ct).ContinueWith(t => t.Result > 0, ct);
        }
    }
}
