using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Global;
public class FuelMeasurementHistoryMap : IEntityTypeConfiguration<FuelMeasurementHistory>
{
    public void Configure(EntityTypeBuilder<FuelMeasurementHistory> builder)
    {
        builder.ToTable("fuel_measurement_history");
        builder.HasKey(fm => fm.Id);
        builder.Property(fm => fm.Id).HasColumnName("id").ValueGeneratedOnAdd();
        builder.Property(fm => fm.Volume).HasColumnName("volume").HasPrecision(7, 3).IsRequired();
        builder.Property(fm => fm.MeasurementDate).HasColumnName("measurement_date").IsRequired();
        builder.Property(fm => fm.VehicleId).HasColumnName("vehicle_id").IsRequired();
        
        builder.HasOne(fm => fm.Vehicle)
            .WithMany(v => v.FuelMeasurements)
            .HasForeignKey(fm => fm.VehicleId);
    }
}