using Microsoft.EntityFrameworkCore;
using RockyShop.Models;

namespace RockyShop.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}

    public DbSet<Category> Category { get; set; }
    public DbSet<ApplicationType> ApplicationType { get; set; }
}