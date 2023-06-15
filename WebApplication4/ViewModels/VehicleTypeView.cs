using System.ComponentModel.DataAnnotations;

namespace WebApplication4.ViewModels
{
    public class VehicleTypeView
    {
        [Required]
        public int Id { get; set; }
        public string TypeName { get; set; }
    }
}
