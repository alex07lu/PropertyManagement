using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PropertyManagement.Models;
namespace PropertyManagement.Repository
{
    public class MyDbContext : DbContext
    {
        public DbSet<Property> Property { get; set; }
        public DbSet<Renter> Renters { get; set; }
        public DbSet<Expense> Expense { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-DG58OKG\\SQLEXPRESS;Database=PropertyManagement;User Id=alu;Password=123456;TrustServerCertificate=true;");
        }
    }
}
