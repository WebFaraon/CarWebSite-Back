using Microsoft.EntityFrameworkCore;
using CarWebSite_Back.Api.Models;

namespace CarWebSite_Back.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Car> Cars { get; set; }
    }
}