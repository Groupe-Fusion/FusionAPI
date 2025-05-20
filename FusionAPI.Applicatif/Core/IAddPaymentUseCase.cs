using FusionAPI.Domain.Models;

namespace FusionAPI.Applicatif.Core
{
    public interface IAddPaymentUseCase
    {
        Task<Payment> ExecuteAsync(Payment payment, CancellationToken ct = default);
    }
}
