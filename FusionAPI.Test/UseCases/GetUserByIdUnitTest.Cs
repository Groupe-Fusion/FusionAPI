using FusionAPI.Applicatif.UseCases;
using FusionAPI.Domain.Models;
using FusionAPI.Domain.Repositories.Core;
using Moq;

namespace FusionAPI.Test.UseCases
{
    public class GetUserByIdUnitTest
    {
        [Fact]
        public async void Success()
        {
            var userId = 1;
            var userRepositoryMoq = new Mock<IUserRepository>();
            userRepositoryMoq.Setup(x => x.GetUserByIdAsync(userId, It.IsAny<CancellationToken>()))
                .ReturnsAsync(new User
                {
                    Id = userId,
                    FirstName = "John",
                    LastName = "Doe"
                });
            var getUserByIdUseCase = new GetUserByIdUseCase(userRepositoryMoq.Object);
            var user = await getUserByIdUseCase.ExecuteAsync(userId, CancellationToken.None);
            // Assert
            Assert.NotNull(user);
            Assert.Equal(userId, user.Id);
        }

        [Fact]
        public async void Failure()
        {
            var userRepositoryMoq = new Mock<IUserRepository>();
            userRepositoryMoq.Setup(x => x.GetUserByIdAsync(It.IsAny<int>(), It.IsAny<CancellationToken>()))
                .ThrowsAsync(new Exception("Email is required."));
            var getUserByIdUseCase = new GetUserByIdUseCase(userRepositoryMoq.Object);
            // Assert
            await Assert.ThrowsAsync<Exception>(() => getUserByIdUseCase.ExecuteAsync(1, CancellationToken.None));
        }
    }
}
