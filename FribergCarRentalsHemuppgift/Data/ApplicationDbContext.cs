using FribergCarRentalsHemuppgift.Areas.Admin.Models;
using FribergCarRentalsHemuppgift.Models;
using Microsoft.EntityFrameworkCore;

namespace FribergCarRentalsHemuppgift.Data

{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<AdminModel> Admins { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<BookingOrder> BookingOrders { get; set; }  

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    }
}
