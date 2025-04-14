using FusionAPI.Applicatif.Core;
using FusionAPI.Domain.Models;
using FusionAPI.Domain.Repositories.Core;

namespace FusionAPI.Applicatif.UseCases
{
    public class GetAllUsersUseCase : IGetAllUsersUseCase
    {
        private readonly IUserRepository _userRepository;
        public GetAllUsersUseCase(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<IList<User>> ExecuteAsync(CancellationToken ct = default)
        {
            return await _userRepository.GetAllUsersAsync(ct);
        }
    }
}
