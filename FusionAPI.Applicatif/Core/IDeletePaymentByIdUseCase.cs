namespace FusionAPI.Applicatif.Core
{
    public interface IDeletePaymentByIdUseCase
    {
        Task<bool> ExecuteAsync(int paymentId, CancellationToken ct = default);
    }
}
