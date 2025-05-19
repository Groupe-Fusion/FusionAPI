namespace FusionAPI.DTO.Requests
{
    public class AddReservationRequest
    {
    }

    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ReservationDto> Reservations { get; set; }
    }

    public class ReservationDto
    {
        public int Id { get; set; }
        public string BookTitle { get; set; }
        // Pas de propriété User ici, pour éviter le cycle
    }

}
