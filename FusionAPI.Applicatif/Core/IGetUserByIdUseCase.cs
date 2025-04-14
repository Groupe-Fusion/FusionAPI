using FusionAPI.Domain.Models;

namespace FusionAPI.Applicatif.Core
{
    public interface IGetUserByIdUseCase
    {
        Task<User> ExecuteAsync(int userId, CancellationToken ct = default);
    }
}