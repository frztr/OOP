using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Global;
public class PlannedMaintenanceScheduleMap : IEntityTypeConfiguration<PlannedMaintenanceSchedule>
{
    public void Configure(EntityTypeBuilder<PlannedMaintenanceSchedule> builder)
    {
        builder.ToTable("planned_maintenance_schedule");
        builder.HasKey(pms => pms.Id);
        builder.Property(pms => pms.Id).HasColumnName("id").ValueGeneratedOnAdd();
        builder.Property(pms => pms.PlannedDate).HasColumnName("planned_date").IsRequired();
        builder.Property(pms => pms.MaintenanceTypeId).HasColumnName("maintenance_type_id").IsRequired();
        builder.Property(pms => pms.VehicleId).HasColumnName("vehicle_id").IsRequired();
        
        builder.HasOne(pms => pms.MaintenanceType)
            .WithMany(mt => mt.PlannedMaintenances)
            .HasForeignKey(pms => pms.MaintenanceTypeId);
            
        builder.HasOne(pms => pms.Vehicle)
            .WithMany(v => v.PlannedMaintenances)
            .HasForeignKey(pms => pms.VehicleId);
    }
}