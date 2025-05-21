using FusionAPI.Applicatif.UseCases;
using FusionAPI.Domain.Repositories.Core;
using Moq;

namespace FusionAPI.TestReservation.UseCases
{
    public class GetAllReservationsUnitTest
    {
        [Fact]
        public async void Success()
        {
            // Arrange
            var reservationRepositoryMoq = new Mock<IReservationRepository>();

            reservationRepositoryMoq.Setup(repo => repo.GetAllReservationsAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(new List<Domain.Models.Reservation>
                {
                    new Domain.Models.Reservation
                    {
                        ReservationId = 1,
                        ReservationStatus = "Pending",
                        Name = "Test Reservation 1",
                        Description = "Test Description 1",
                        UserId = 1,
                        CreatedByName = "Test User 1",
                        StartLocation = "Start Location 1",
                        EndLocation = "End Location 1",
                        User = new Domain.Models.User { FirstName = "John", LastName = "Doe" },
                    },
                    new Domain.Models.Reservation
                    {
                        ReservationId = 2,
                        ReservationStatus = "Confirmed",
                        Name = "Test Reservation 2",
                        Description = "Test Description 2",
                        UserId = 2,
                        CreatedByName = "Test User 2",
                        StartLocation = "Start Location 2",
                        EndLocation = "End Location 2",
                        User = new Domain.Models.User { FirstName = "Jane", LastName = "Smith" },
                    }
                });

            var getAllReservationsUseCase = new FusionAPI.Applicatif.UseCases.GetAllReservationsUseCase(reservationRepositoryMoq.Object);
            // Act
            var result = await getAllReservationsUseCase.ExecuteAsync();
            // Assert
            Assert.NotNull(result);

        }

        [Fact]
        public async void Failure()
        {
            // Arrange
            var reservationRepositoryMoq = new Mock<IReservationRepository>();

            reservationRepositoryMoq.Setup(repo => repo.GetAllReservationsAsync(It.IsAny<CancellationToken>()))
                .ThrowsAsync(new InvalidOperationException("Erreur lors de la récupération des réservations."));

            var getAllReservationsUseCase = new FusionAPI.Applicatif.UseCases.GetAllReservationsUseCase(reservationRepositoryMoq.Object);
            // Act
            var exception = await Assert.ThrowsAsync<InvalidOperationException>(() => getAllReservationsUseCase.ExecuteAsync());
            // Assert
            Assert.NotNull(exception);
        }
    }
}
