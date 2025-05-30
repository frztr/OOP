
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace Global;
public class AppDbContext : IdentityDbContext<IdentityUser>
{

public DbSet<Post> PostList { get; set; }

	
public DbSet<FriendshipsStatus> FriendshipsStatusList { get; set; }

	
public DbSet<User> UserList { get; set; }

	
public DbSet<Message> MessageList { get; set; }

	
public DbSet<CommentLike> CommentLikeList { get; set; }

	
public DbSet<Role> RoleList { get; set; }

	
public DbSet<Comment> CommentList { get; set; }

	
public DbSet<Country> CountryList { get; set; }

	
public DbSet<PostLike> PostLikeList { get; set; }

	
public DbSet<City> CityList { get; set; }

	
public DbSet<Friendships> FriendshipsList { get; set; }

    public AppDbContext(){}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=DBName231323124;Username=postgres;Password=postgres");
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new PostMap())
	.ApplyConfiguration(new FriendshipsStatusMap())
	.ApplyConfiguration(new UserMap())
	.ApplyConfiguration(new MessageMap())
	.ApplyConfiguration(new CommentLikeMap())
	.ApplyConfiguration(new RoleMap())
	.ApplyConfiguration(new CommentMap())
	.ApplyConfiguration(new CountryMap())
	.ApplyConfiguration(new PostLikeMap())
	.ApplyConfiguration(new CityMap())
	.ApplyConfiguration(new FriendshipsMap());
        Role r = new Role { 
            
            Id = 1,
            Name = "admin" 
        };
            builder.Entity<Role>().HasData(r);
            builder.Entity<User>().HasData(
                new User {
                    Email = "adm",
                    Login = "admin",
                    PasswordHash = Convert.ToHexString(
                    MD5.Create().ComputeHash(System.Text.Encoding.ASCII.GetBytes("admin"))),
                    Id = 1,
                    RoleId = 1
                });
        base.OnModelCreating(builder);
    }
}