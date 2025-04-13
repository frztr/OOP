using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Global;
public class MaintenanceHistoryMap : IEntityTypeConfiguration<MaintenanceHistory>
{
    public void Configure(EntityTypeBuilder<MaintenanceHistory> builder)
    {
        builder.ToTable("maintenance_history");
        builder.HasKey(d => d.Id);
        builder.Property(d => d.Id).HasColumnName("id").ValueGeneratedOnAdd();
		builder.Property(d => d.Date).HasColumnName("date").IsRequired();
		builder.Property(d => d.VehicleId).HasColumnName("vehicle_id").IsRequired();
		builder.Property(d => d.MaintenanceTypeId).HasColumnName("maintenance_type_id").IsRequired();
		builder.Property(d => d.CompletedWork).HasColumnName("completed_work").HasMaxLength(2000).IsRequired();
		builder.Property(d => d.AutomechanicId).HasColumnName("automechanic_id").IsRequired();
        
                    
        builder.HasOne(d => d.Vehicle)
                .WithMany(e => e.MaintenanceHistories)
                .HasForeignKey(d => d.VehicleId);

		builder.HasOne(d => d.MaintenanceType)
                .WithMany(e => e.MaintenanceHistories)
                .HasForeignKey(d => d.MaintenanceTypeId);

		builder.HasOne(d => d.Automechanic)
                .WithMany(e => e.MaintenanceHistories)
                .HasForeignKey(d => d.AutomechanicId);    
        
    }
}