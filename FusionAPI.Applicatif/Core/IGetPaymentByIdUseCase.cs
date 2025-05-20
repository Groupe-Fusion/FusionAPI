using FusionAPI.Domain.Models;

namespace FusionAPI.Applicatif.Core
{
    public interface IGetPaymentByIdUseCase
    {
        Task<Payment?> ExecuteAsync(int paymentId, CancellationToken ct = default);
    }
}