using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Global;
public class CityMap : IEntityTypeConfiguration<City>
{
    public void Configure(EntityTypeBuilder<City> builder)
    {
        builder.ToTable("city");
        builder.HasKey(d => d.Id);
        builder.Property(d => d.Id).HasColumnName("id").ValueGeneratedOnAdd();
		builder.Property(d => d.Name).HasColumnName("name").HasMaxLength(50).IsRequired();
		builder.Property(d => d.CountryId).HasColumnName("country_id").IsRequired();
        
                    
        builder.HasOne(d => d.Country)
                .WithMany(e => e.Cities)
                .HasForeignKey(d => d.CountryId);    
        
    }
}