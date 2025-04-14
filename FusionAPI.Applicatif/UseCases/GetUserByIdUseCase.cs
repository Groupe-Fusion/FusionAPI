using FusionAPI.Applicatif.Core;
using FusionAPI.Domain.Models;
using FusionAPI.Domain.Repositories.Core;

namespace FusionAPI.Applicatif.UseCases
{
    public class GetUserByIdUseCase : IGetUserByIdUseCase
    {
        private readonly IUserRepository _userRepository;
        public GetUserByIdUseCase(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<User> ExecuteAsync(int userId, CancellationToken ct = default)
        {
            var user = await _userRepository.GetUserByIdAsync(userId, ct);
            if (user == null)
                throw new InvalidOperationException("Utilisateur introuvable avec cet ID.");
            return user;
        }
    }
}
