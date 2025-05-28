using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Global;
public class FuelMeasurementHistoryMap : IEntityTypeConfiguration<FuelMeasurementHistory>
{
    public void Configure(EntityTypeBuilder<FuelMeasurementHistory> builder)
    {
        builder.ToTable("fuel_measurement_history");
        builder.HasKey(d => d.Id);
        builder.Property(d => d.Id).HasColumnName("id").ValueGeneratedOnAdd();
		builder.Property(d => d.Volume).HasColumnName("volume").IsRequired();
		builder.Property(d => d.MeasurementDate).HasColumnName("measurement_date").IsRequired();
		builder.Property(d => d.VehicleId).HasColumnName("vehicle_id").IsRequired();
        
                    
        builder.HasOne(d => d.Vehicle)
                .WithMany(e => e.FuelMeasurementHistories)
                .HasForeignKey(d => d.VehicleId);    
        
    }
}