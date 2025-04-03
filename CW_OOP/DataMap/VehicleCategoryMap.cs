using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Global;
public class VehicleCategoryMap : IEntityTypeConfiguration<VehicleCategory>
{
    public void Configure(EntityTypeBuilder<VehicleCategory> builder)
    {
        builder.ToTable("vehicle_category");
        builder.HasKey(vc => vc.Id);
        builder.Property(vc => vc.Id).HasColumnName("id").ValueGeneratedOnAdd();
        builder.Property(vc => vc.Name).HasColumnName("name").HasMaxLength(25).IsRequired();
        builder.HasIndex(vc => vc.Name).IsUnique();
    }
}