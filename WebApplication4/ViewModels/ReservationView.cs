using WebApplication4.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication4.ViewModels
{
    public class ReservationView
    {
        [Required]
        public int Id { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Poczatek")]
        public DateTime reservationStart { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Koniec")]
        public DateTime reservationEnd { get; set; }

        public virtual Vehicle? Vehicle { get; set; }
    }
}
