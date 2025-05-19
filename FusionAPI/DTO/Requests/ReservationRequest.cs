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
    }
}
