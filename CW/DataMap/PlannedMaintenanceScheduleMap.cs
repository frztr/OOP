using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Global;
public class PlannedMaintenanceScheduleMap : IEntityTypeConfiguration<PlannedMaintenanceSchedule>
{
    public void Configure(EntityTypeBuilder<PlannedMaintenanceSchedule> builder)
    {
        builder.ToTable("planned_maintenance_schedule");
        builder.HasKey(d => d.Id);
        builder.Property(d => d.Id).HasColumnName("id").ValueGeneratedOnAdd();
		builder.Property(d => d.PlannedDate).HasColumnName("planned_date").IsRequired();
		builder.Property(d => d.MaintenanceTypeId).HasColumnName("maintenance_type_id").IsRequired();
		builder.Property(d => d.VehicleId).HasColumnName("vehicle_id").IsRequired();
        
                    
        builder.HasOne(d => d.MaintenanceType)
                .WithMany(e => e.PlannedMaintenanceSchedules)
                .HasForeignKey(d => d.MaintenanceTypeId);

		builder.HasOne(d => d.Vehicle)
                .WithMany(e => e.PlannedMaintenanceSchedules)
                .HasForeignKey(d => d.VehicleId);    
        
    }
}