using FusionAPI.Domain.Models;

namespace FusionAPI.Applicatif.Core
{
    public interface IAddUserUseCase
    {
        Task<User> ExecuteAsync(User newUser, CancellationToken cancellationToken);
    }
}