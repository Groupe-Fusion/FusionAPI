using System;
using AutoFixture;
using FusionAPI.Applicatif.UseCases;
using FusionAPI.Domain.Models;
using FusionAPI.Domain.Repositories.Core;
using Moq;

namespace FusionAPI.Test.UseCases
{
    public class AddUserUnitTest
    {
        [Fact]
        public async void Success()
        {
            var user = new User
            {
                Email = "test@example.com",
                FirstName = "John",
                LastName = "Doe"
            };

            var userRepositoryMoq = new Mock<IUserRepository>();
            userRepositoryMoq.Setup(x => x.AddUserAsync(It.IsAny<User>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(user);

            var addUserUseCase = new AddUserUseCase(userRepositoryMoq.Object);
            var newUser = await addUserUseCase.ExecuteAsync(user, CancellationToken.None);

            // Assert
            Assert.NotNull(newUser);
            Assert.Equal(user.Email, newUser.Email);
            Assert.Equal(user.FirstName, newUser.FirstName);
        }

        [Fact]
        public async void Failure()
        {
            var user = new User
            {
                Email = "test@example.com",
                FirstName = "John",
                LastName = "Doe"
            };

            var userRepositoryMoq = new Mock<IUserRepository>();
            userRepositoryMoq.Setup(x => x.AddUserAsync(It.IsAny<User>(), It.IsAny<CancellationToken>()))
                .ThrowsAsync(new Exception("Email is required."));
            var addUserUseCase = new AddUserUseCase(userRepositoryMoq.Object);
            // Assert
            await Assert.ThrowsAsync<Exception>(() => addUserUseCase.ExecuteAsync(user, CancellationToken.None));
        }
    }
}
