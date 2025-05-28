
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace Global;
public class AppDbContext : IdentityDbContext<IdentityUser>
{

public DbSet<Automechanic> AutomechanicList { get; set; }

	
public DbSet<OilType> OilTypeList { get; set; }

	
public DbSet<SparePart> SparePartList { get; set; }

	
public DbSet<Vehicle> VehicleList { get; set; }

	
public DbSet<Driver> DriverList { get; set; }

	
public DbSet<MaintenanceHistory> MaintenanceHistoryList { get; set; }

	
public DbSet<MaintenanceType> MaintenanceTypeList { get; set; }

	
public DbSet<MileageMeasurementHistory> MileageMeasurementHistoryList { get; set; }

	
public DbSet<DocumentType> DocumentTypeList { get; set; }

	
public DbSet<User> UserList { get; set; }

	
public DbSet<VehiclePhoto> VehiclePhotoList { get; set; }

	
public DbSet<PlannedMaintenanceSchedule> PlannedMaintenanceScheduleList { get; set; }

	
public DbSet<Manufacturer> ManufacturerList { get; set; }

	
public DbSet<RepairConsumedSparePart> RepairConsumedSparePartList { get; set; }

	
public DbSet<Role> RoleList { get; set; }

	
public DbSet<VehicleStatus> VehicleStatusList { get; set; }

	
public DbSet<RefuelingHistory> RefuelingHistoryList { get; set; }

	
public DbSet<VehicleDocument> VehicleDocumentList { get; set; }

	
public DbSet<VehicleCategory> VehicleCategoryList { get; set; }

	
public DbSet<FuelMeasurementHistory> FuelMeasurementHistoryList { get; set; }

	
public DbSet<FuelType> FuelTypeList { get; set; }

	
public DbSet<RepairHistory> RepairHistoryList { get; set; }

	
public DbSet<VehicleModel> VehicleModelList { get; set; }

    public AppDbContext(){}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=DBName;Username=postgres;Password=postgres");
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new AutomechanicMap())
	.ApplyConfiguration(new OilTypeMap())
	.ApplyConfiguration(new SparePartMap())
	.ApplyConfiguration(new VehicleMap())
	.ApplyConfiguration(new DriverMap())
	.ApplyConfiguration(new MaintenanceHistoryMap())
	.ApplyConfiguration(new MaintenanceTypeMap())
	.ApplyConfiguration(new MileageMeasurementHistoryMap())
	.ApplyConfiguration(new DocumentTypeMap())
	.ApplyConfiguration(new UserMap())
	.ApplyConfiguration(new VehiclePhotoMap())
	.ApplyConfiguration(new PlannedMaintenanceScheduleMap())
	.ApplyConfiguration(new ManufacturerMap())
	.ApplyConfiguration(new RepairConsumedSparePartMap())
	.ApplyConfiguration(new RoleMap())
	.ApplyConfiguration(new VehicleStatusMap())
	.ApplyConfiguration(new RefuelingHistoryMap())
	.ApplyConfiguration(new VehicleDocumentMap())
	.ApplyConfiguration(new VehicleCategoryMap())
	.ApplyConfiguration(new FuelMeasurementHistoryMap())
	.ApplyConfiguration(new FuelTypeMap())
	.ApplyConfiguration(new RepairHistoryMap())
	.ApplyConfiguration(new VehicleModelMap());
        Role r = new Role { 
            
            Id = 1,
            Name = "admin" 
        };
            builder.Entity<Role>().HasData(r);
            builder.Entity<User>().HasData(
                new User {
                    Fio = "adm",
                    Login = "admin",
                    PasswordHash = Convert.ToHexString(
                    MD5.Create().ComputeHash(System.Text.Encoding.ASCII.GetBytes("admin"))),
                    Id = 1,
                    RoleId = 1
                });
        base.OnModelCreating(builder);
    }
}