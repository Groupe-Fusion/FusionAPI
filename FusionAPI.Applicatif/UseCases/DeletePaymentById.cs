using FusionAPI.Applicatif.Core;
using FusionAPI.Domain.Repositories.Core;

namespace FusionAPI.Applicatif.UseCases
{
    public class DeletePaymentById : IDeletePaymentByIdUseCase
    {
        private readonly IPaymentRepository _paymentRepositories;
        public DeletePaymentById(IPaymentRepository paymentRepositories)
        {
            _paymentRepositories = paymentRepositories;
        }
        public async Task<bool> ExecuteAsync(int paymentId, CancellationToken ct = default)
        {
            return await _paymentRepositories.DeletePaymentAsync(paymentId, ct);
        }
    }
}
