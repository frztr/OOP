using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Global;
public class RepairHistoryMap : IEntityTypeConfiguration<RepairHistory>
{
    public void Configure(EntityTypeBuilder<RepairHistory> builder)
    {
        builder.ToTable("repair_history");
        builder.HasKey(d => d.Id);
        builder.Property(d => d.Id).HasColumnName("id").ValueGeneratedOnAdd();
		builder.Property(d => d.VehicleId).HasColumnName("vehicle_id").IsRequired();
		builder.Property(d => d.DatetimeBegin).HasColumnName("datetime_begin").IsRequired();
		builder.Property(d => d.DatetimeEnd).HasColumnName("datetime_end");
		builder.Property(d => d.CompletedWork).HasColumnName("completed_work").HasMaxLength(2000).IsRequired();
		builder.Property(d => d.Price).HasColumnName("price");
		builder.Property(d => d.ServicestationTinNumber).HasColumnName("servicestation_tin_number");
		builder.Property(d => d.AutomechanicId).HasColumnName("automechanic_id");
        
                    
        builder.HasOne(d => d.Vehicle)
                .WithMany(e => e.RepairHistories)
                .HasForeignKey(d => d.VehicleId);

		builder.HasOne(d => d.Automechanic)
                .WithMany(e => e.RepairHistories)
                .HasForeignKey(d => d.AutomechanicId);    
        
    }
}