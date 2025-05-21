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
    public class GetPaymentByIdUnitTest
    {
        [Fact]
        public async void Success()
        {
            // Arrange
            var paymentId = 1;
            var paymentRepositoryMoq = new Mock<IPaymentRepository>();
            paymentRepositoryMoq.Setup(x => x.GetPaymentByIdAsync(paymentId, It.IsAny<CancellationToken>()))
                .ReturnsAsync(new Payment { PaymentId = paymentId });
            var getPaymentByIdUseCase = new GetPaymentByIdUseCase(paymentRepositoryMoq.Object);
            // Act
            var result = await getPaymentByIdUseCase.ExecuteAsync(paymentId);
            // Assert
            Assert.NotNull(result);
            Assert.Equal(paymentId, result.PaymentId);
        }

        [Fact]
        public async void Failure()
        {
            // Arrange
            var paymentId = 1;
            var paymentRepositoryMoq = new Mock<IPaymentRepository>();
            paymentRepositoryMoq.Setup(x => x.GetPaymentByIdAsync(paymentId, It.IsAny<CancellationToken>()))
                .ReturnsAsync((Payment)null);
            var getPaymentByIdUseCase = new GetPaymentByIdUseCase(paymentRepositoryMoq.Object);
            // Act
            var result = await getPaymentByIdUseCase.ExecuteAsync(paymentId);
            // Assert
            Assert.Null(result);
        }
    }
}
