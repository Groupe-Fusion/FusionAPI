using FusionAPI.Domain.Models;
using FusionAPI.Domain.Repositories.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FusionAPI.Applicatif.UseCases
{
    public class GetAllPaymentsUseCase
    {
        private readonly IPaymentRepository _paymentRepositories;
        public GetAllPaymentsUseCase(IPaymentRepository paymentRepositories)
        {
            _paymentRepositories = paymentRepositories;
        }
        public async Task<List<Payment>> ExecuteAsync(CancellationToken ct = default)
        {
            return await _paymentRepositories.GetAllPaymentsAsync(ct);
        }
    }
}
