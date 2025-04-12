
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Global;
public class AppDbContext : IdentityDbContext<IdentityUser>
{

    public AppDbContext(){}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=AMSDb;Username=postgres;Password=postgres");
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
    builder;
        base.OnModelCreating(builder);
    }
}