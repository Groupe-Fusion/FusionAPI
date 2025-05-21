using FusionAPI.Applicatif.UseCases;
using FusionAPI.Domain.Models;
using FusionAPI.Domain.Repositories.Core;
using Moq;

namespace FusionAPI.TestReservation.UseCases
{
    public class AddReservationUnitTest
    {
        [Fact]
        public async void Success()
        {
            // Arrange
            var reservation = new Reservation
            {
                ReservationId = 1,
                ReservationStatus = "Pending",
                Name = "Test Reservation",
                Description = "Test Description",
                UserId = 1,
                CreatedByName = "Test User",
                StartLocation = "Start Location",
                EndLocation = "End Location",
                User = new User { FirstName = "John", LastName = "Doe" },
            };
            var mockReservationRepository = new Mock<IReservationRepository>();
            mockReservationRepository.Setup(repo => repo.AddReservationAsync(It.IsAny<Reservation>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(reservation);
            var addReservationUseCase = new AddReservationUseCase(mockReservationRepository.Object);
            // Act
            var result = await addReservationUseCase.ExecuteAsync(reservation);
            // Assert
            Assert.NotNull(result);
            Assert.Equal(reservation.ReservationId, result.ReservationId);
            Assert.Equal(reservation.Name, result.Name);
            Assert.Equal(reservation.Description, result.Description);
            Assert.Equal(reservation.UserId, result.UserId);
            Assert.Equal(reservation.CreatedByName, result.CreatedByName);
            Assert.Equal(reservation.StartLocation, result.StartLocation);
            Assert.Equal(reservation.EndLocation, result.EndLocation);
            Assert.Equal(reservation.User.FirstName, result.User.FirstName);
            Assert.Equal(reservation.User.LastName, result.User.LastName);
        }

        [Fact]
        public async void Failure()
        {
            // Arrange
            var reservation = new Reservation
            {
                ReservationId = 1,
                ReservationStatus = "Pending",
                Name = "Test Reservation",
                Description = "Test Description",
                UserId = 1,
                CreatedByName = "Test User",
                StartLocation = "Start Location",
                EndLocation = "End Location",
                User = new User { FirstName = "John", LastName = "Doe" },
            };
            var mockReservationRepository = new Mock<IReservationRepository>();
            mockReservationRepository.Setup(repo => repo.AddReservationAsync(It.IsAny<Reservation>(), It.IsAny<CancellationToken>()))
                .ThrowsAsync(new Exception("Error adding reservation"));
            var addReservationUseCase = new AddReservationUseCase(mockReservationRepository.Object);
            // Act & Assert
            await Assert.ThrowsAsync<Exception>(() => addReservationUseCase.ExecuteAsync(reservation));
        }
    }
}