using FusionAPI.Domain.Models;

namespace FusionAPI.Applicatif.Core
{
    public interface IGetAllUsersUseCase
    {
        Task<IList<User>> ExecuteAsync(CancellationToken ct = default);
    }
}