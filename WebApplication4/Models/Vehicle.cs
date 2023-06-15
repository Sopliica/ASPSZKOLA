using WebApplication4.Repository;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication4.Models
{
    public class Vehicle : IEntity<int>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public virtual VehicleType? VehicleType { get; set; }

        [ForeignKey("VehicleType")]
        public int VehicleTypeId { get; set; }
        
        public decimal Price { get; set; }  

    }
}
