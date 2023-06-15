using WebApplication4.Repository;

namespace WebApplication4.Models
{
    public class Rental : IEntity<int>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<Rental>? vehicles { get; set; }
        
    }
}
