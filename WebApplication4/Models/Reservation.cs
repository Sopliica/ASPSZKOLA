using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication4.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public DateTime reservationStart { get; set; }
        public DateTime reservationEnd { get; set; }
        public virtual Vehicle Vehicle { get; set; }

        [ForeignKey("Vehicle")]
        public int VehicleId { get; set; }
    }
}
