namespace BlazorWebAssemblyDemo.Server.Data;

public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
    }
    public DbSet<Country> Countries { get; set; }
    public DbSet<Media> Media { get; set; }
}
