namespace FusionAPI.DTO.Requests
{
    public class ReservationRequest
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int UserId { get; set; }
        public string CreatedByName { get; set; } = string.Empty;
        public string StartLocation { get; set; } = string.Empty;
        public string EndLocation { get; set; } = string.Empty;
        public string Dimension { get; set; } = string.Empty;
        public int Weight { get; set; }
        public bool IsNow { get; set; } = false;
        public DateTime DeliveryDate { get; set; } = DateTime.Now;
        public string Category { get; set; } = string.Empty;
        public int Rating { get; set; } = 0;
        public double Price { get; set; } = 0.0;
        public double InHour { get; set; } = 0.0;
        public string RecipientName { get; set; } = string.Empty;
        public string RecipientPhone { get; set; } = string.Empty;
        public string RecipientAddress { get; set; } = string.Empty;
        public string RecipientCity { get; set; } = string.Empty;
        public string RecipientPostalCode { get; set; } = string.Empty;
        public string PackageType { get; set; } = string.Empty;
        public bool isFragile { get; set; } = false;
        public string ReservationStatus { get; set; } = string.Empty;

        public int? PrestataireId { get; set; }
    }
}
