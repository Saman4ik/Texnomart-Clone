using Microsoft.EntityFrameworkCore;
using Texnomart.Domain.Entities;

namespace Texnomart.Data.DbContextt;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Product> Products { get; set; }
} 