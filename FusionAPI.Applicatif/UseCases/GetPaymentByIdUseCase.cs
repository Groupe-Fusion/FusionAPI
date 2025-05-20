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
    public class GetPaymentByIdUseCase : IGetPaymentByIdUseCase
    {
        private readonly IPaymentRepository _paymentRepositories;
        public GetPaymentByIdUseCase(IPaymentRepository paymentRepositories)
        {
            _paymentRepositories = paymentRepositories;
        }
        public async Task<Payment?> ExecuteAsync(int paymentId, CancellationToken ct = default)
        {
            return await _paymentRepositories.GetPaymentByIdAsync(paymentId, ct);
        }
    }
}
