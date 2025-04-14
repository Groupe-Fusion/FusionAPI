namespace FusionAPI.DTO.Requests
{
    public class ReservationRequest
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int UserId { get; set; }
        public string CreatedByName { get; set; } = string.Empty;
    }
}
