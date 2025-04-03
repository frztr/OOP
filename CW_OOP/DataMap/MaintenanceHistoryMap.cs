using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Global;
public class MaintenanceHistoryMap : IEntityTypeConfiguration<MaintenanceHistory>
{
    public void Configure(EntityTypeBuilder<MaintenanceHistory> builder)
    {
        builder.ToTable("maintenance_history");
        builder.HasKey(mh => mh.Id);
        builder.Property(mh => mh.Id).HasColumnName("id").ValueGeneratedOnAdd();
        builder.Property(mh => mh.Date).HasColumnName("date").IsRequired();
        builder.Property(mh => mh.VehicleId).HasColumnName("vehicle_id").IsRequired();
        builder.Property(mh => mh.MaintenanceTypeId).HasColumnName("maintenance_type_id").IsRequired();
        builder.Property(mh => mh.CompletedWork).HasColumnName("completed_work").HasMaxLength(2000).IsRequired();
        builder.Property(mh => mh.AutomechanicId).HasColumnName("automechanic_id").IsRequired();
        
        builder.HasOne(mh => mh.Vehicle)
            .WithMany(v => v.Maintenances)
            .HasForeignKey(mh => mh.VehicleId);
            
        builder.HasOne(mh => mh.MaintenanceType)
            .WithMany(mt => mt.MaintenanceHistories)
            .HasForeignKey(mh => mh.MaintenanceTypeId);
            
        builder.HasOne(mh => mh.Automechanic)
            .WithMany(a => a.MaintenanceHistories)
            .HasForeignKey(mh => mh.AutomechanicId);
    }
}