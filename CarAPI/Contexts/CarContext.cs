using Microsoft.EntityFrameworkCore;
using CarAPI.Models;

namespace CarAPI.Contexts
{
    public class CarContext : DbContext
    {
        public CarContext(DbContextOptions<CarContext>
            options) : base(options) { }

        public DbSet<Car> cars { get; set; }
    }
}
