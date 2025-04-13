using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Global;
public class OilTypeMap : IEntityTypeConfiguration<OilType>
{
    public void Configure(EntityTypeBuilder<OilType> builder)
    {
        builder.ToTable("oil_type");
        builder.HasKey(d => d.Id);
        builder.Property(d => d.Id).HasColumnName("id").ValueGeneratedOnAdd();
		builder.Property(d => d.Name).HasColumnName("name").HasMaxLength(10).IsRequired();
		builder.Property(d => d.FuelTypeId).HasColumnName("fuel_type_id").IsRequired();
        builder.HasIndex(v => v.Name).IsUnique();
                    
        builder.HasOne(d => d.FuelType)
                .WithMany(e => e.OilTypes)
                .HasForeignKey(d => d.FuelTypeId);    
        
    }
}