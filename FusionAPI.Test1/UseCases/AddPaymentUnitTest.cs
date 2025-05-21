using FusionAPI.Applicatif.UseCases;
using FusionAPI.Domain.Models;
using FusionAPI.Domain.Repositories.Core;
using Moq;

namespace FusionAPI.Test1.UseCases
{
    public class AddPaymentUnitTest
    {
        [Fact]
        public async void Success()
        {
            // Arrange
            var payment = new Payment
            {
                TotalPrice = 100,
                DeliveryPrice = 10,
                ServicePrice = 5,
                CardOwner = "John Doe",
                CardNumber = "1234567890123456",
                CardCvc = "123",
                CardExpiry = "12/25",
                IsSavedForFutureUse = true,
                FacturationAddress = "123 Main St",
                FacturationCity = "New York",
                FacturationPostalCode = "10001",
                FacturationCountry = "USA",
                IsPaid = false
            };

            var paymentRepositoyMoq = new Mock<IPaymentRepository>();
            paymentRepositoyMoq.Setup(x => x.AddPaymentAsync(It.IsAny<Payment>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((Payment p, CancellationToken ct) => p);

            var addPaymentUseCase = new AddPaymentUseCase(paymentRepositoyMoq.Object);
            var newPayment = await addPaymentUseCase.ExecuteAsync(payment);

            // Assert
            Assert.NotNull(newPayment);
            Assert.Equal(payment.TotalPrice, newPayment.TotalPrice);
            Assert.Equal(payment.DeliveryPrice, newPayment.DeliveryPrice);
            Assert.Equal(payment.ServicePrice, newPayment.ServicePrice);
            Assert.Equal(payment.CardOwner, newPayment.CardOwner);
            Assert.Equal(payment.CardNumber, newPayment.CardNumber);
            Assert.Equal(payment.CardCvc, newPayment.CardCvc);
            Assert.Equal(payment.CardExpiry, newPayment.CardExpiry);
            Assert.Equal(payment.IsSavedForFutureUse, newPayment.IsSavedForFutureUse);
        }

        [Fact]
        public async void Failure()
        {
            // Arrange
            var payment = new Payment
            {
                TotalPrice = 100,
                DeliveryPrice = 10,
                ServicePrice = 5,
                CardOwner = "John Doe",
                CardNumber = "1234567890123456",
                CardCvc = "123",
                CardExpiry = "12/25",
                IsSavedForFutureUse = true,
                FacturationAddress = "123 Main St",
                FacturationCity = "New York",
                FacturationPostalCode = "10001",
                FacturationCountry = "USA",
                IsPaid = false
            };
            var paymentRepositoyMoq = new Mock<IPaymentRepository>();
            paymentRepositoyMoq.Setup(x => x.AddPaymentAsync(It.IsAny<Payment>(), It.IsAny<CancellationToken>()))
                .ThrowsAsync(new Exception("Database error"));
            var addPaymentUseCase = new AddPaymentUseCase(paymentRepositoyMoq.Object);
            // Act & Assert
            await Assert.ThrowsAsync<Exception>(() => addPaymentUseCase.ExecuteAsync(payment));
        }
    }
}
