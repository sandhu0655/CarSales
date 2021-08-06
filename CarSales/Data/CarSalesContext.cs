using CarSales.Models;
using Microsoft.EntityFrameworkCore;

namespace CarSales.Data
{
    public class CarSalesContext : DbContext
    {
        public CarSalesContext (DbContextOptions<CarSalesContext> options)
            : base(options)
        {
        }

        public DbSet<Car> Car { get; set; }

        public DbSet<BookingCars> BookingCars { get; set; }

        public DbSet<ContactUs> ContactUs { get; set; }
    }
}
