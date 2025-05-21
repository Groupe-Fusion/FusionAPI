namespace FusionAPI.Domain.Models
{
    public class User
    {
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        // FK
        public virtual ICollection<Reservation> Reservations { get; set; } = [];
        public virtual ICollection<Reservation> Prestations { get; set;} = [];
    }
}
