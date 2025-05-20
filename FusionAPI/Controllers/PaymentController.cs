using FusionAPI.Applicatif.Core;
using FusionAPI.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace FusionAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController : ControllerBase // Fix: Inherit from ControllerBase
    {
        private readonly IAddPaymentUseCase _addPaymentUseCase;
        private readonly IGetAllPaymentsUseCase _getAllPaymentsUseCase;
        private readonly IGetPaymentByIdUseCase _getPaymentByIdUseCase;
        private readonly IDeletePaymentByIdUseCase _deletePaymentByIdUseCase;

        public PaymentController(IAddPaymentUseCase addPaymentUseCase, IGetAllPaymentsUseCase getAllPaymentsUseCase, IGetPaymentByIdUseCase getPaymentByIdUseCase, IDeletePaymentByIdUseCase deletePaymentByIdUseCase)
        {
            _addPaymentUseCase = addPaymentUseCase;
            _getAllPaymentsUseCase = getAllPaymentsUseCase;
            _getPaymentByIdUseCase = getPaymentByIdUseCase;
            _deletePaymentByIdUseCase = deletePaymentByIdUseCase;
        }

        [HttpPost]
        public async Task<IActionResult> AddPayment([FromBody] Payment request, CancellationToken ct)
        {
            try
            {
                if (request == null)
                {
                    return BadRequest("Invalid payment data.");
                }
                var payment = new Payment
                {
                    FacturationAddress = request.FacturationAddress,
                    FacturationCity = request.FacturationCity,
                    FacturationCountry = request.FacturationCountry,
                    FacturationPostalCode = request.FacturationPostalCode,
                    CardCvc = request.CardCvc,
                    ServicePrice = request.ServicePrice,
                    CardExpiry = request.CardExpiry,
                    CardNumber = request.CardNumber,
                    CardOwner = request.CardOwner,
                    DeliveryPrice = request.DeliveryPrice,
                    IsSavedForFutureUse = request.IsSavedForFutureUse,
                    IsPaid = request.IsPaid,
                    ReservationId = request.ReservationId,
                    TotalPrice = request.TotalPrice
                };
                var createdPayment = await _addPaymentUseCase.ExecuteAsync(payment, ct);
                return CreatedAtAction(nameof(GetPaymentById), new { paymentId = createdPayment.PaymentId }, createdPayment);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPayments(CancellationToken ct)
        {
            try
            {
                var payments = await _getAllPaymentsUseCase.ExecuteAsync(ct);
                return Ok(payments);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{paymentId}")]
        public async Task<IActionResult> GetPaymentById(int paymentId, CancellationToken ct)
        {
            try
            {
                var payment = await _getPaymentByIdUseCase.ExecuteAsync(paymentId, ct);
                return payment != null ? Ok(payment) : NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{paymentId}")]
        public async Task<IActionResult> DeletePaymentById(int paymentId, CancellationToken ct)
        {
            try
            {
                var result = await _deletePaymentByIdUseCase.ExecuteAsync(paymentId, ct);
                return result ? NoContent() : NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
