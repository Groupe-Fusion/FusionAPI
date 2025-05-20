using FusionAPI.Domain.Models;

namespace FusionAPI.Applicatif.Core
{
    public interface IGetAllPaymentsUseCase
    {
        Task<List<Payment>> ExecuteAsync(CancellationToken ct = default);
    }
}
