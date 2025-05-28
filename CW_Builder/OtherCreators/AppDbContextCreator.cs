using System.Text.RegularExpressions;

public class AppDbContextCreator
{
    public static string Create(Entity[] entities,
        string host,
        string port,
        string dbName,
        string hostUser,
        string password
    )
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
        optionsBuilder.UseNpgsql(""Host={host};Port={port};Database={dbName};Username={hostUser};Password={password}"");
    }}

    protected override void OnModelCreating(ModelBuilder builder)
    {{
        builder{String.Join("\n\t", entities.Select(x => $@".ApplyConfiguration(new {x.Name}Map())"))};
        Role r = new Role {{ 
            {String.Join(",\n", entities.FirstOrDefault(x => x.Name == "Role")
            .Props.Where(x => x.Name != "Name" && !x.PK && x.IsRequired).Select(x =>
            {
                return GenValue(x);
            }))},
            Id = 1,
            Name = \""admin\"" 
        }};
            builder.Entity<Role>().HasData(r);
            builder.Entity<User>().HasData(
                new User {{
                {String.Join(",\n", entities.FirstOrDefault(x => x.Name == "User")
                    .Props.Where(x =>
                    !new List<string>(){
                        "Login",
                        "Password",
                        entities.FirstOrDefault(x => x.Name == "User")
                        .Props.FirstOrDefault(x=>x.Type == "Role").Name }.Contains(x.Name) &&
                    !x.PK &&
                    x.IsRequired).Select(x =>
                    {
                        return GenValue(x);
                    }))},
                    Login = \""admin\"",
                    PasswordHash = Convert.ToHexString(
                    MD5.Create().ComputeHash(System.Text.Encoding.ASCII.GetBytes(\""admin\""))),
                    Id = 1,
                    {entities.FirstOrDefault(x => x.Name == "User")
                        .Props.FirstOrDefault(x=>x.Type == "Role").Name} = 1
                }});
        base.OnModelCreating(builder);
    }}
}}";
    }

    private static string GenValue(EntityProp x)
    {
        string value = "";
        if (Regex.IsMatch(x.Type, "varchar\\([0-9]+\\)|char\\([0-9]+\\)|text"))
            value = $"\"adm\"";
        if (new List<string>() { "boolean", "bool" }.Contains(x.Type))
        {
            value = "false";
        }
        if (new List<string>() { "smallserial", "smallint", "int2", "serial2" }.Contains(x.Type) ||
        new List<string>() { "serial", "int", "integer", "int4", "serial4" }.Contains(x.Type) ||
        new List<string>() { "bigint", "int8", "bigserial", "serial8" }.Contains(x.Type) ||
        Regex.IsMatch(x.Type, "numeric|float4|float8|decimal|double precision")
        )
        {
            value = "1";
        }

        return $@"{x.Name} = {value}";
    }
}