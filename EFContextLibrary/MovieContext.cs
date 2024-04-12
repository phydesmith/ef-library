using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EFContextLibrary;

public class MovieContext : DbContext
{
    public DbSet<Movie> Students { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();

        optionsBuilder.UseSqlServer(
            configuration.GetConnectionString("MovieContext")
        );
    }
}