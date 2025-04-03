using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Global;
public class MileageMeasurementHistoryMap : IEntityTypeConfiguration<MileageMeasurementHistory>
{
    public void Configure(EntityTypeBuilder<MileageMeasurementHistory> builder)
    {
        builder.ToTable("mileage_measurement_history");
        builder.HasKey(mm => mm.Id);
        builder.Property(mm => mm.Id).HasColumnName("id").ValueGeneratedOnAdd();
        builder.Property(mm => mm.KmCount).HasColumnName("km_count").HasPrecision(9, 3).IsRequired();
        builder.Property(mm => mm.MeasurementDate).HasColumnName("measurement_date").IsRequired();
        builder.Property(mm => mm.VehicleId).HasColumnName("vehicle_id").IsRequired();
        
        builder.HasOne(mm => mm.Vehicle)
            .WithMany(v => v.MileageMeasurements)
            .HasForeignKey(mm => mm.VehicleId);
    }
}