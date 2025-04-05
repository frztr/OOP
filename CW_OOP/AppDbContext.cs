using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Global;
public class AppDbContext : IdentityDbContext<IdentityUser>
{

    public DbSet<Automechanic> Automechanics { get; set; }
    public DbSet<DocumentType> DocumentTypes { get; set; }
    public DbSet<Driver> Drivers { get; set; }
    public DbSet<FuelMeasurementHistory> FuelMeasurementHistories { get; set; }

    public DbSet<FuelType> FuelTypes { get; set; }

    public DbSet<MaintenanceHistory> MaintenanceHistories { get; set; }

    public DbSet<MaintenanceType> MaintenanceTypes { get; set; }

    public DbSet<Manufacturer> Manufacturers { get; set; }

    public DbSet<MileageMeasurementHistory> MileageMeasurementHistories { get; set; }

    public DbSet<OilType> OilTypes { get; set; }

    public DbSet<PlannedMaintenanceSchedule> PlannedMaintenanceSchedules { get; set; }

    public DbSet<RefuelingHistory> RefuelingHistories { get; set; }

    public DbSet<RepairConsumedSparePart> RepairConsumedSpareParts { get; set; }

    public DbSet<RepairHistory> RepairHistories { get; set; }

    public DbSet<Role> Roles { get; set; }

    public DbSet<SparePart> SpareParts { get; set; }

    public DbSet<User> Users { get; set; }

    public DbSet<Vehicle> Vehicles { get; set; }

    public DbSet<VehicleCategory> VehicleCategories { get; set; }

    public DbSet<VehicleDocument> VehicleDocuments { get; set; }

    public DbSet<VehicleModel> VehicleModels { get; set; }

    public DbSet<VehiclePhoto> VehiclePhotos { get; set; }

    public DbSet<VehicleStatus> VehicleStatuses { get; set; }

    public AppDbContext()
    {
        // Database.EnsureDeleted();
        // Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=AMSDb;Username=postgres;Password=postgres");
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=AMSDb;Username=postgres;Password=postgres");;

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new AutomechanicMap())
            .ApplyConfiguration(new DocumentTypeMap())
            .ApplyConfiguration(new DriverMap())
            .ApplyConfiguration(new FuelMeasurementHistoryMap())
            .ApplyConfiguration(new FuelTypeMap())
            .ApplyConfiguration(new MaintenanceHistoryMap())
            .ApplyConfiguration(new MaintenanceTypeMap())
            .ApplyConfiguration(new ManufacturerMap())
            .ApplyConfiguration(new MileageMeasurementHistoryMap())
            .ApplyConfiguration(new OilTypeMap())
            .ApplyConfiguration(new PlannedMaintenanceScheduleMap())
            .ApplyConfiguration(new RepairHistoryMap())
            .ApplyConfiguration(new RefuelingHistoryMap())
            .ApplyConfiguration(new RepairConsumedSparePartMap())
            .ApplyConfiguration(new RoleMap())
            .ApplyConfiguration(new SparePartMap())
            .ApplyConfiguration(new UserMap())
            .ApplyConfiguration(new VehicleMap())
            .ApplyConfiguration(new VehicleCategoryMap())
            .ApplyConfiguration(new VehicleDocumentMap())
            .ApplyConfiguration(new VehicleModelMap())
            .ApplyConfiguration(new VehiclePhotoMap())
            .ApplyConfiguration(new VehicleStatusMap());
        // Role r = new Role { Id = 1, Name = "admin" };
        // builder.Entity<Role>().HasData(
        //     new Role { Id = 2, Name = "user"},
        //     r
        //     );
        // builder.Entity<User>().HasData(
        //     new User { 
        //         //Role = r,
        //         Login = "admin",
        //         Password = Convert.ToHexString(
        //         MD5.Create().ComputeHash(System.Text.Encoding.ASCII.GetBytes("admin"))),
        //         BirthDate = DateTime.Now,
        //         City = "Moscow",
        //         Email = "admin@admin.ru",
        //         PhoneNumber = 79991234567,
        //         UserFullName = "admin",
        //         UserId = 1,
        //         RoleId = 1
        //     });

        base.OnModelCreating(builder);
    }
}