using Microsoft.Build.Framework;
using WebApplication4.Models;

namespace WebApplication4.ViewModels
{
    public class RentalView
    {
        [Required]
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<Rental>? vehicles { get; set; }
    }
}
