using FusionAPI.Applicatif.UseCases;
using FusionAPI.Domain.Models;
using FusionAPI.Domain.Repositories.Core;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FusionAPI.Test1.UseCases
{
    public class GetAllPaymentUnitTest
    {
        [Fact]
        public async void Success()
        {
            // Arrange
            var paymentRepositoryMoq = new Mock<IPaymentRepository>();
            paymentRepositoryMoq.Setup(x => x.GetAllPaymentsAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(new List<Payment> { new Payment() });
            var getAllPaymentUseCase = new GetAllPaymentsUseCase(paymentRepositoryMoq.Object);
            // Act
            var result = await getAllPaymentUseCase.ExecuteAsync();
            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async void Failure()
        {
            // Arrange
            var paymentRepositoryMoq = new Mock<IPaymentRepository>();
            paymentRepositoryMoq.Setup(x => x.GetAllPaymentsAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(new List<Payment>());
            var getAllPaymentUseCase = new GetAllPaymentsUseCase(paymentRepositoryMoq.Object);
            // Act
            var result = await getAllPaymentUseCase.ExecuteAsync();
            // Assert
            Assert.Empty(result);
        }
    }
}
