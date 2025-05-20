namespace FusionAPI.Domain.Models
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public int ReservationId { get; set; }
        public decimal DeliveryPrice { get; set; }
        public decimal ServicePrice { get; set; }
        public decimal TotalPrice { get; set; }
        public string CardOwner { get; set; } = string.Empty;
        public string CardNumber { get; set; } = string.Empty;
        public string CardCvc { get; set; } = string.Empty;
        public string CardExpiry { get; set; } = string.Empty;
        public bool IsSavedForFutureUse { get; set; }
        public string FacturationAddress { get; set; } = string.Empty;
        public string FacturationCity { get; set; } = string.Empty;
        public string FacturationPostalCode { get; set; } = string.Empty;
        public string FacturationCountry { get; set; } = string.Empty;
        public bool IsPaid { get; set; }
    }
}
