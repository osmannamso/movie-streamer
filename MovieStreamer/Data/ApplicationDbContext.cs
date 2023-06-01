using MovieStreamer.Models;
using Microsoft.EntityFrameworkCore;

namespace MovieStreamer.Data;

public class ApplicationDbContext : DbContext
{
    protected readonly IConfiguration Configuration;
    
    public ApplicationDbContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // connect to postgres with connection string from app settings
        options.UseNpgsql(Configuration.GetConnectionString("WebApiDatabase"));
    }
    
    public DbSet<Movie> Movies { get; set; }
}
