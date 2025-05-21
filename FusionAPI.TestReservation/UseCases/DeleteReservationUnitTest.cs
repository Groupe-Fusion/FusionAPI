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
    public class DeleteReservationUnitTest
    {
        [Fact]
        public async void Success()
        {
            // Arrange
            var reservation = new Reservation
            {
                ReservationId = 3,
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
            mockReservationRepository.Setup(repo => repo.DeleteReservationAsync(It.IsAny<int>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(reservation);
            var deleteReservationUseCase = new DeleteReservationUseCase(mockReservationRepository.Object);
            // Act
            var result = await deleteReservationUseCase.ExecuteAsync(reservation.ReservationId);
            // Assert
            Assert.NotNull(result);
            Assert.Equal(reservation.ReservationId, result.ReservationId);
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
            mockReservationRepository.Setup(repo => repo.DeleteReservationAsync(It.IsAny<int>(), It.IsAny<CancellationToken>()))
                .ThrowsAsync(new InvalidOperationException("Réservation introuvable avec ces ID."));
            var deleteReservationUseCase = new DeleteReservationUseCase(mockReservationRepository.Object);
            // Act
            var exception = await Assert.ThrowsAsync<InvalidOperationException>(() => deleteReservationUseCase.ExecuteAsync(reservation.ReservationId));
            // Assert
            Assert.Equal("Réservation introuvable avec ces ID.", exception.Message);
            mockReservationRepository.Verify(repo => repo.DeleteReservationAsync(It.IsAny<int>(), It.IsAny<CancellationToken>()), Times.Once);
            mockReservationRepository.Verify(repo => repo.GetReservationByIdAsync(It.IsAny<int>(), It.IsAny<CancellationToken>()), Times.Once);
            mockReservationRepository.Verify(repo => repo.GetReservationByIdAsync(reservation.ReservationId, It.IsAny<CancellationToken>()), Times.Once);
            mockReservationRepository.Verify(repo => repo.DeleteReservationAsync(reservation.ReservationId, It.IsAny<CancellationToken>()), Times.Never);
        }
    }
}
