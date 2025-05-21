using FusionAPI.Applicatif.UseCases;
using FusionAPI.Domain.Repositories.Core;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FusionAPI.Test1.UseCases
{
    public class DeletePaymentUnitTest
    {
        [Fact]
        public async void Success()
        {
            // Arrange
            var paymentId = 1;
            var paymentRepositoryMoq = new Mock<IPaymentRepository>();
            paymentRepositoryMoq.Setup(x => x.DeletePaymentByIdAsync(paymentId, It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);
            var deletePaymentUseCase = new DeletePaymentByIdUseCase(paymentRepositoryMoq.Object);
            // Act
            var result = await deletePaymentUseCase.ExecuteAsync(paymentId);
            // Assert
            Assert.True(result);
        }

        [Fact]
        public async void Failure()
        {
            // Arrange
            var paymentId = 1;
            var paymentRepositoryMoq = new Mock<IPaymentRepository>();
            paymentRepositoryMoq.Setup(x => x.DeletePaymentByIdAsync(paymentId, It.IsAny<CancellationToken>()))
                .ReturnsAsync(false);
            var deletePaymentUseCase = new DeletePaymentByIdUseCase(paymentRepositoryMoq.Object);
            // Act
            var result = await deletePaymentUseCase.ExecuteAsync(paymentId);
            // Assert
            Assert.False(result);
        }
    }
}
