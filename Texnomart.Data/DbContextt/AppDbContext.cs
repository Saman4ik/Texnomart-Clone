using Microsoft.EntityFrameworkCore;
using Texnomart.Domain.Entities;
using Texnomart.Domain.Enums;

namespace Texnomart.Data.DbContextt;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasData(
           new User
           {
               Id = 1,
               FrisName = "Saman4ik",
               LastName = "Tillayev",
               Address = "Fergana",
               Email = "tillayev0703@gmail.com",
               Gender = Gender.Male,
               Password = "4c5b397b90d90be1ce89eca4bc21bff9baa09c356609e079d5c1d8a50227a0a2",
               Role = Role.SupperAdmin,
           });
    }
} 