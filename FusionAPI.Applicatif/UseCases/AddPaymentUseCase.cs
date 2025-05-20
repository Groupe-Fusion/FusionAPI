using FusionAPI.Applicatif.Core;
using FusionAPI.Domain.Models;
using FusionAPI.Domain.Repositories.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FusionAPI.Applicatif.UseCases
{
    public class AddPaymentUseCase : IAddPaymentUseCase
    {
        private readonly IPaymentRepository _paymentRepositories;
        public AddPaymentUseCase(IPaymentRepository paymentRepositories)
        {
            _paymentRepositories = paymentRepositories;
        }
        public async Task<Payment> ExecuteAsync(Payment payment, CancellationToken ct = default)
        {
            return await _paymentRepositories.AddPaymentAsync(payment, ct);
        }
    }
}
