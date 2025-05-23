
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Global;
public class AppDbContext : IdentityDbContext<IdentityUser>
{

public DbSet<Payment> PaymentList { get; set; }

	
public DbSet<User> UserList { get; set; }

	
public DbSet<Booking> BookingList { get; set; }

	
public DbSet<EventCategory> EventCategoryList { get; set; }

	
public DbSet<BookingStatus> BookingStatusList { get; set; }

	
public DbSet<Event> EventList { get; set; }

	
public DbSet<PaymentStatus> PaymentStatusList { get; set; }

	
public DbSet<Role> RoleList { get; set; }

	
public DbSet<Review> ReviewList { get; set; }

	
public DbSet<Location> LocationList { get; set; }

	
public DbSet<PaymentMethod> PaymentMethodList { get; set; }

    public AppDbContext(){}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=AMSDb;Username=postgres;Password=postgres");
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
    builder.ApplyConfiguration(new PaymentMap())
	.ApplyConfiguration(new UserMap())
	.ApplyConfiguration(new BookingMap())
	.ApplyConfiguration(new EventCategoryMap())
	.ApplyConfiguration(new BookingStatusMap())
	.ApplyConfiguration(new EventMap())
	.ApplyConfiguration(new PaymentStatusMap())
	.ApplyConfiguration(new RoleMap())
	.ApplyConfiguration(new ReviewMap())
	.ApplyConfiguration(new LocationMap())
	.ApplyConfiguration(new PaymentMethodMap());
        base.OnModelCreating(builder);
    }
}