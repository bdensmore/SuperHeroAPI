using Microsoft.EntityFrameworkCore;
using SuperHeroAPI.Models;

namespace SuperHeroAPI.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options ) : base(options)
    {
        
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlServer("Server=127.0.0.1;Database=superherodb;User=SA;Password=Password123!;TrustServerCertificate=true;");
    }

    public DbSet<SuperHero>? SuperHeroes { get; set; }
}