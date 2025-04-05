
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Global;
public class OilTypeMap : IEntityTypeConfiguration<OilType>
{
    public void Configure(EntityTypeBuilder<OilType> builder)
    {
        builder.ToTable("oil_type");
        builder.HasKey(ot => ot.Id);
        builder.Property(ot => ot.Id).HasColumnName("id").ValueGeneratedOnAdd();
        builder.Property(ot => ot.Name).HasColumnName("name").HasMaxLength(10).IsRequired();
        builder.Property(ot => ot.FuelTypeId).HasColumnName("fuel_type_id").IsRequired();
        builder.HasIndex(ot => ot.Name).IsUnique();
        
        builder.HasOne(ot => ot.FuelType)
            .WithMany(ft => ft.OilTypes)
            .HasForeignKey(ot => ot.FuelTypeId);
    }
}