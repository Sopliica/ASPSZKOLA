using System.ComponentModel.DataAnnotations;
using WebApplication4.Models;

namespace WebApplication4.ViewModels
{
    public class VehicleView
    {
        [Required]
        public int Id { get; set; }
        public string? Name { get; set; }
        public virtual VehicleType? VehicleType { get; set; }
        [Range(0, 9999.99)]
        public decimal Price { get; set; }
    }
}
