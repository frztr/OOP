using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Global;
public class RefuelingHistoryMap : IEntityTypeConfiguration<RefuelingHistory>
{
    public void Configure(EntityTypeBuilder<RefuelingHistory> builder)
    {
        builder.ToTable("refueling_history");
        builder.HasKey(d => d.Id);
        builder.Property(d => d.Id).HasColumnName("id").ValueGeneratedOnAdd();
		builder.Property(d => d.Volume).HasColumnName("volume").IsRequired();
		builder.Property(d => d.OilTypeId).HasColumnName("oil_type_id").IsRequired();
		builder.Property(d => d.FuelstationTinNumber).HasColumnName("fuelstation_tin_number").IsRequired();
		builder.Property(d => d.VehicleId).HasColumnName("vehicle_id").IsRequired();
		builder.Property(d => d.Price).HasColumnName("price").IsRequired();
		builder.Property(d => d.Datetime).HasColumnName("datetime").IsRequired();
		builder.Property(d => d.DriverId).HasColumnName("driver_id").IsRequired();
        
                    
        builder.HasOne(d => d.OilType)
                .WithMany(e => e.RefuelingHistories)
                .HasForeignKey(d => d.OilTypeId);

		builder.HasOne(d => d.Vehicle)
                .WithMany(e => e.RefuelingHistories)
                .HasForeignKey(d => d.VehicleId);

		builder.HasOne(d => d.Driver)
                .WithMany(e => e.RefuelingHistories)
                .HasForeignKey(d => d.DriverId);    
        
    }
}