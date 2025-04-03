using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Global;

public class FuelTypeMap : IEntityTypeConfiguration<FuelType>
{
    public void Configure(EntityTypeBuilder<FuelType> builder)
    {
        builder.ToTable("fuel_type");
        builder.HasKey(ft => ft.Id);
        builder.Property(ft => ft.Id).HasColumnName("id").ValueGeneratedOnAdd();
        builder.Property(ft => ft.Name).HasColumnName("name").HasMaxLength(20).IsRequired();
        builder.HasIndex(ft => ft.Name).IsUnique();
    }
}