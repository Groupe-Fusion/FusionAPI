using FusionAPI.Applicatif.UseCases;
using FusionAPI.Domain.Models;
using FusionAPI.Domain.Repositories.Core;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FusionAPI.TestReservation.UseCases
{
    public class GetReservationByIdUnitTest
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
            mockReservationRepository.Setup(repo => repo.GetReservationByIdAsync(It.IsAny<int>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(reservation);
            var getReservationByIdUseCase = new GetReservationByIdUseCase(mockReservationRepository.Object);
            // Act
            var result = await getReservationByIdUseCase.ExecuteAsync(reservation.ReservationId);
            // Assert
            Assert.NotNull(result);
            Assert.Equal(reservation.ReservationId, result.ReservationId);
        }

        [Fact]
        public async void Failure()
        {
            // Arrange
            var reservationId = 1;
            var mockReservationRepository = new Mock<IReservationRepository>();
            mockReservationRepository.Setup(repo => repo.GetReservationByIdAsync(It.IsAny<int>(), It.IsAny<CancellationToken>()))
                .ThrowsAsync(new InvalidOperationException("Réservation introuvable avec ces ID."));
            var getReservationByIdUseCase = new GetReservationByIdUseCase(mockReservationRepository.Object);
            // Act
            var exception = await Assert.ThrowsAsync<InvalidOperationException>(() => getReservationByIdUseCase.ExecuteAsync(reservationId));
            // Assert
            Assert.Equal("Réservation introuvable avec ces ID.", exception.Message);
        }
    }
}
