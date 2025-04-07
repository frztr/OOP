public class AppDbContextCreator
{
    public static string Create(Entity[] entities)
    {
        return $@"
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Global;
public class AppDbContext : IdentityDbContext<IdentityUser>
{{
{String.Join("\n\t", entities.Select(x => $@"
public DbSet<{x.Name}> {x.Name}List {{ get; set; }}
"))}
    public AppDbContext(){{}}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {{
        optionsBuilder.UseNpgsql(""Host=localhost;Port=5432;Database=AMSDb;Username=postgres;Password=postgres"");
    }}

    protected override void OnModelCreating(ModelBuilder builder)
    {{
    builder{String.Join("\n\t", entities.Select(x => $@".ApplyConfiguration(new {x.Name}Map())"))};
        base.OnModelCreating(builder);
    }}
}}";
    }
}