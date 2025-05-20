using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FusionAPI.DTO.Requests
{
    public class AddPaymentRequest
    {
        public string PaymentMethod { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }
        public string OrderId { get; set; }
    }
}
