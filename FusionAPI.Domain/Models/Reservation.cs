using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FusionAPI.Domain.Models
{
    public class Reservation
    {
        public int ReservationId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public int UserId { get; set; }
        public required virtual User User { get; set; }

        public string CreatedByName { get; set; } = string.Empty;
    }
}
