using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Global;
public class VehicleMap : IEntityTypeConfiguration<Vehicle>
{
    public void Configure(EntityTypeBuilder<Vehicle> builder)
    {
        builder.ToTable("vehicle");
        builder.HasKey(d => d.Id);
        builder.Property(d => d.Id).HasColumnName("id").ValueGeneratedOnAdd();
		builder.Property(d => d.VinNumber).HasColumnName("vin_number").HasMaxLength(17).IsRequired();
		builder.Property(d => d.PlateNumber).HasColumnName("plate_number").HasMaxLength(15).IsRequired();
		builder.Property(d => d.VehiclemodelId).HasColumnName("vehiclemodel_id").IsRequired();
		builder.Property(d => d.ReleaseYear).HasColumnName("release_year").IsRequired();
		builder.Property(d => d.RegistrationDate).HasColumnName("registration_date").IsRequired();
		builder.Property(d => d.StatusId).HasColumnName("status_id").IsRequired();
        builder.HasIndex(v => v.VinNumber).IsUnique();
		builder.HasIndex(v => v.PlateNumber).IsUnique();
                    
        builder.HasOne(d => d.VehicleModel)
                .WithMany(e => e.Vehicles)
                .HasForeignKey(d => d.VehiclemodelId);

		builder.HasOne(d => d.VehicleStatus)
                .WithMany(e => e.Vehicles)
                .HasForeignKey(d => d.StatusId);    
        
    }
}