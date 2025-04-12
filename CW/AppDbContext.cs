
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Global;
public class AppDbContext : IdentityDbContext<IdentityUser>
{

public DbSet<Vehicle> VehicleList { get; set; }

	
public DbSet<MileageMeasurementHistory> MileageMeasurementHistoryList { get; set; }

	
public DbSet<RefuelingHistory> RefuelingHistoryList { get; set; }

	
public DbSet<OilType> OilTypeList { get; set; }

	
public DbSet<RepairConsumedSparePart> RepairConsumedSparePartList { get; set; }

	
public DbSet<MaintenanceHistory> MaintenanceHistoryList { get; set; }

	
public DbSet<FuelMeasurementHistory> FuelMeasurementHistoryList { get; set; }

	
public DbSet<PlannedMaintenanceSchedule> PlannedMaintenanceScheduleList { get; set; }

	
public DbSet<VehiclePhoto> VehiclePhotoList { get; set; }

	
public DbSet<Manufacturer> ManufacturerList { get; set; }

	
public DbSet<VehicleStatus> VehicleStatusList { get; set; }

	
public DbSet<VehicleModel> VehicleModelList { get; set; }

	
public DbSet<SparePart> SparePartList { get; set; }

	
public DbSet<Role> RoleList { get; set; }

	
public DbSet<VehicleCategory> VehicleCategoryList { get; set; }

	
public DbSet<MaintenanceType> MaintenanceTypeList { get; set; }

	
public DbSet<VehicleDocument> VehicleDocumentList { get; set; }

	
public DbSet<Driver> DriverList { get; set; }

	
public DbSet<User> UserList { get; set; }

	
public DbSet<FuelType> FuelTypeList { get; set; }

	
public DbSet<RepairHistory> RepairHistoryList { get; set; }

	
public DbSet<DocumentType> DocumentTypeList { get; set; }

	
public DbSet<Automechanic> AutomechanicList { get; set; }

    public AppDbContext(){}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=AutoManagementSystemDb;Username=postgres;Password=postgres");
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
    builder.ApplyConfiguration(new VehicleMap())
	.ApplyConfiguration(new MileageMeasurementHistoryMap())
	.ApplyConfiguration(new RefuelingHistoryMap())
	.ApplyConfiguration(new OilTypeMap())
	.ApplyConfiguration(new RepairConsumedSparePartMap())
	.ApplyConfiguration(new MaintenanceHistoryMap())
	.ApplyConfiguration(new FuelMeasurementHistoryMap())
	.ApplyConfiguration(new PlannedMaintenanceScheduleMap())
	.ApplyConfiguration(new VehiclePhotoMap())
	.ApplyConfiguration(new ManufacturerMap())
	.ApplyConfiguration(new VehicleStatusMap())
	.ApplyConfiguration(new VehicleModelMap())
	.ApplyConfiguration(new SparePartMap())
	.ApplyConfiguration(new RoleMap())
	.ApplyConfiguration(new VehicleCategoryMap())
	.ApplyConfiguration(new MaintenanceTypeMap())
	.ApplyConfiguration(new VehicleDocumentMap())
	.ApplyConfiguration(new DriverMap())
	.ApplyConfiguration(new UserMap())
	.ApplyConfiguration(new FuelTypeMap())
	.ApplyConfiguration(new RepairHistoryMap())
	.ApplyConfiguration(new DocumentTypeMap())
	.ApplyConfiguration(new AutomechanicMap());
        base.OnModelCreating(builder);
    }
}