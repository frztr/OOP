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
        var roleProps = entities.FirstOrDefault(x => x.Name == "Role")
            .Props.Where(x => x.Name != "Name" && !x.PK && x.IsRequired);
        var userProps = entities.FirstOrDefault(x => x.Name == "User")
                    .Props.Where(x =>
                    !new List<string>(){
                        "Login",
                        "PasswordHash",
                        entities.FirstOrDefault(x => x.Name == "User")
                        .Props.FirstOrDefault(x=>x.FK == "Role").Name }.Contains(x.Name) &&
                    !x.PK &&
                    x.IsRequired);
        return $@"
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

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
            {String.Join(",\n", roleProps.Select(x =>
            {
                return GenValue(x);
            }))}{(roleProps.Count()>0?",":"")}
            {entities.FirstOrDefault(x => x.Name == "Role")
            .Props.FirstOrDefault(x => x.PK).Name} = 1,
            Name = ""admin"" 
        }};
            builder.Entity<Role>().HasData(r);
            builder.Entity<User>().HasData(
                new User {{
                    {String.Join(",\n\t\t\t", userProps.Select(x =>
                    {
                        return GenValue(x);
                    }))}{(userProps.Count()>0?",":"")}
                    Login = ""admin"",
                    PasswordHash = Convert.ToHexString(
                    MD5.Create().ComputeHash(System.Text.Encoding.ASCII.GetBytes(""admin""))),
                    {entities.FirstOrDefault(x => x.Name == "User")
            .Props.FirstOrDefault(x => x.PK).Name} = 1,
                    {entities.FirstOrDefault(x => x.Name == "User")
                        .Props.FirstOrDefault(x => x.FK == "Role").Name} = 1
                }});
        base.OnModelCreating(builder);
    }}
}}";
    }

    private static string GenValue(EntityProp x)
    {
        string value = "";
        if (x.Type == "string")
            value = $"\"adm\"";
        if (x.Type == "bool")
        {
            value = "false";
        }
        if (x.Type == "DateTime")
        {
            value = "DateTime.Now";
        }
        if (new List<string>() { "short", "int", "long", "decimal" }.Contains(x.Type))
        {
            value = "1";
        }

        return $@"{x.Name} = {value}";
    }
}