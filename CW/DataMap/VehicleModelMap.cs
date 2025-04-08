using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Global;
public class VehicleModelMap : IEntityTypeConfiguration<VehicleModel>
{
    public void Configure(EntityTypeBuilder<VehicleModel> builder)
    {
        builder.ToTable("vehicle_model");
        builder.HasKey(vm => vm.Id);
        builder.Property(vm => vm.Id).HasColumnName("id").ValueGeneratedOnAdd();
        builder.Property(vm => vm.Name).HasColumnName("name").HasMaxLength(40).IsRequired();
        builder.Property(vm => vm.ManufacturerId).HasColumnName("manufacturer_id").IsRequired();
        builder.Property(vm => vm.VehicleCategoryId).HasColumnName("vehicle_category_id").IsRequired();
        builder.Property(vm => vm.Power).HasColumnName("power").IsRequired();
        builder.Property(vm => vm.FuelTypeId).HasColumnName("fuel_type_id").IsRequired();
        builder.Property(vm => vm.LoadCapacity).HasColumnName("load_capacity").IsRequired();
        
        builder.HasOne(vm => vm.Manufacturer)
            .WithMany(m => m.VehicleModels)
            .HasForeignKey(vm => vm.ManufacturerId);
            
        builder.HasOne(vm => vm.VehicleCategory)
            .WithMany(vc => vc.VehicleModels)
            .HasForeignKey(vm => vm.VehicleCategoryId);
            
        builder.HasOne(vm => vm.FuelType)
            .WithMany(ft => ft.VehicleModels)
            .HasForeignKey(vm => vm.FuelTypeId);
    }
}