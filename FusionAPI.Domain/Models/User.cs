using System.ComponentModel.DataAnnotations;

namespace FusionAPI.Domain.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
