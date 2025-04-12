using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Global;
public class VehicleMap : IEntityTypeConfiguration<Vehicle>
{
    public void Configure(EntityTypeBuilder<Vehicle> builder)
    {
        builder.ToTable("vehicle");
        builder.HasKey(v => v.Id);
        builder.Property(v => v.Id).HasColumnName("id").ValueGeneratedOnAdd();
        builder.Property(v => v.VinNumber).HasColumnName("vin_number").HasMaxLength(17).IsRequired();
        builder.Property(v => v.PlateNumber).HasColumnName("plate_number").HasMaxLength(15).IsRequired();
        builder.Property(v => v.VehicleModelId).HasColumnName("vehiclemodel_id").IsRequired();
        builder.Property(v => v.ReleaseYear).HasColumnName("release_year").IsRequired();
        builder.Property(v => v.RegistrationDate).HasColumnName("registration_date").IsRequired();
        builder.Property(v => v.StatusId).HasColumnName("status_id").IsRequired();
        builder.HasIndex(v => v.VinNumber).IsUnique();
        builder.HasIndex(v => v.PlateNumber).IsUnique();
        
        builder.HasOne(v => v.VehicleModel)
            .WithMany(vm => vm.Vehicles)
            .HasForeignKey(v => v.VehicleModelId);
            
        builder.HasOne(v => v.VehicleStatus)
            .WithMany(vs => vs.Vehicles)
            .HasForeignKey(v => v.StatusId);
    }
}