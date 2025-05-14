using System.ComponentModel.DataAnnotations;

namespace FusionAPI.Domain.Models
{
    public class User
    {
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string ConfirmPassword { get; set; } = string.Empty;
        public bool AcceptConditions { get; set; } = false;

        // FK
        public virtual ICollection<Reservation> Reservations { get; set; } = [];
    }
}
