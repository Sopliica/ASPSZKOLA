using WebApplication4.Models;

namespace WebApplication4.DB;

public class Seeder
{
    public static async Task Seed(ApplicationDbContext context)
    {

        List<VehicleType> vehicleTypes = new()
        {
            new VehicleType()
            {
                Id = 1,
                TypeName = "Rower"
            },
            new VehicleType()
            {
                Id = 2,
                TypeName = "Samochod"
            }
        };
        List<Vehicle> vehicles = new()
        {
            new Vehicle()
            {
                Name = "Pojazd",
                Price = 5
            }
        };

     
        await context.AddRangeAsync(vehicleTypes);
        await context.AddRangeAsync(vehicles);
        await context.SaveChangesAsync();

    }
}
