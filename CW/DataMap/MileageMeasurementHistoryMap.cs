using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Global;
public class MileageMeasurementHistoryMap : IEntityTypeConfiguration<MileageMeasurementHistory>
{
    public void Configure(EntityTypeBuilder<MileageMeasurementHistory> builder)
    {
        builder.ToTable("mileage_measurement_history");
        builder.HasKey(d => d.Id);
        builder.Property(d => d.Id).HasColumnName("id").ValueGeneratedOnAdd();
		builder.Property(d => d.KmCount).HasColumnName("km_count").IsRequired();
		builder.Property(d => d.MeasurementDate).HasColumnName("measurement_date").IsRequired();
		builder.Property(d => d.VehicleId).HasColumnName("vehicle_id").IsRequired();
        
                    
        builder.HasOne(d => d.Vehicle)
                .WithMany(e => e.MileageMeasurementHistories)
                .HasForeignKey(d => d.VehicleId);    
        
    }
}