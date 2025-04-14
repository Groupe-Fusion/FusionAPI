using FusionAPI.Domain.Repositories.Core;
using FusionAPI.Applicatif.Core;
using FusionAPI.Domain.Models;

namespace FusionAPI.Applicatif.UseCases
{
    public class AddUserUseCase : IAddUserUseCase
    {
        private readonly IUserRepository _userRepository;
        public AddUserUseCase(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> ExecuteAsync(User newUser, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(newUser.Email))
                throw new ApplicationException("Email is required.");

            await _userRepository.AddUserAsync(newUser, cancellationToken);
            return newUser;
        }
    }
}
