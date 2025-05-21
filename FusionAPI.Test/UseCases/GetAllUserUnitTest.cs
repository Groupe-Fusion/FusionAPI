using FusionAPI.Applicatif.UseCases;
using FusionAPI.Domain.Models;
using FusionAPI.Domain.Repositories.Core;
using Moq;

namespace FusionAPI.Test.UseCases
{
    public class GetAllUserUnitTest
    {
        [Fact]
        public async void Success()
        {
            var userRepositoryMoq = new Mock<IUserRepository>();
            userRepositoryMoq.Setup(x => x.GetAllUsersAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(new List<User>());
            var getAllUserUseCase = new GetAllUsersUseCase(userRepositoryMoq.Object);
            var users = await getAllUserUseCase.ExecuteAsync(CancellationToken.None);
            // Assert
            Assert.NotNull(users);
        }

        [Fact]
        public async void Failure()
        {
            var userRepositoryMoq = new Mock<IUserRepository>();
            userRepositoryMoq.Setup(x => x.GetAllUsersAsync(It.IsAny<CancellationToken>()))
                .ThrowsAsync(new Exception("Email is required."));
            var getAllUserUseCase = new GetAllUsersUseCase(userRepositoryMoq.Object);
            // Assert
            await Assert.ThrowsAsync<Exception>(() => getAllUserUseCase.ExecuteAsync(CancellationToken.None));
        }
    }
}
