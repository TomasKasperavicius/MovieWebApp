
using Microsoft.EntityFrameworkCore;
using Models;
namespace Database;

public class MySqlDbContext : DbContext
{
    public MySqlDbContext(DbContextOptions<MySqlDbContext> optionsBuilder) : base(optionsBuilder)
    {

    }
    public DbSet<User> User { get; set; }
    public DbSet<Movie> Movie { get; set; }
}