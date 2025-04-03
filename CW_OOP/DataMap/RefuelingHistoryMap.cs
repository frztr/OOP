using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Global;
public class RefuelingHistoryMap : IEntityTypeConfiguration<RefuelingHistory>
{
    public void Configure(EntityTypeBuilder<RefuelingHistory> builder)
    {
        builder.ToTable("refueling_history");
        builder.HasKey(rh => rh.Id);
        builder.Property(rh => rh.Id).HasColumnName("id").ValueGeneratedOnAdd();
        builder.Property(rh => rh.Volume).HasColumnName("volume").HasPrecision(7, 3).IsRequired();
        builder.Property(rh => rh.OilTypeId).HasColumnName("oil_type_id").IsRequired();
        builder.Property(rh => rh.FuelStationTinNumber).HasColumnName("fuelstation_tin_number").IsRequired();
        builder.Property(rh => rh.VehicleId).HasColumnName("vehicle_id").IsRequired();
        builder.Property(rh => rh.Price).HasColumnName("price").HasPrecision(9, 2).IsRequired();
        builder.Property(rh => rh.DateTime).HasColumnName("datetime").IsRequired();
        builder.Property(rh => rh.DriverId).HasColumnName("driver_id").IsRequired();
        
        builder.HasOne(rh => rh.OilType)
            .WithMany(ot => ot.Refuelings)
            .HasForeignKey(rh => rh.OilTypeId);
            
        builder.HasOne(rh => rh.Vehicle)
            .WithMany(v => v.Refuelings)
            .HasForeignKey(rh => rh.VehicleId);
            
        builder.HasOne(rh => rh.Driver)
            .WithMany(d => d.RefuelingHistories)
            .HasForeignKey(rh => rh.DriverId);
    }
}