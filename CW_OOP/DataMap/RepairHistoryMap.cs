using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Global;
public class RepairHistoryMap : IEntityTypeConfiguration<RepairHistory>
{
    public void Configure(EntityTypeBuilder<RepairHistory> builder)
    {
        builder.ToTable("repair_history");
        builder.HasKey(rh => rh.Id);
        builder.Property(rh => rh.Id).HasColumnName("id").ValueGeneratedOnAdd();
        builder.Property(rh => rh.VehicleId).HasColumnName("vehicle_id").IsRequired();
        builder.Property(rh => rh.DateTime).HasColumnName("datetime").IsRequired();
        builder.Property(rh => rh.CompletedWork).HasColumnName("completed_work").HasMaxLength(2000).IsRequired();
        builder.Property(rh => rh.Price).HasColumnName("price").HasPrecision(9, 2);
        builder.Property(rh => rh.ServiceStationTinNumber).HasColumnName("servicestation_tin_number");
        builder.Property(rh => rh.AutomechanicId).HasColumnName("automechanic_id");
        
        builder.HasOne(rh => rh.Vehicle)
            .WithMany(v => v.Repairs)
            .HasForeignKey(rh => rh.VehicleId);
            
        builder.HasOne(rh => rh.Automechanic)
            .WithMany(a => a.RepairHistories)
            .HasForeignKey(rh => rh.AutomechanicId);
    }
}