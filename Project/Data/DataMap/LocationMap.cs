using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Global;
public class LocationMap : IEntityTypeConfiguration<Location>
{
    public void Configure(EntityTypeBuilder<Location> builder)
    {
        builder.ToTable("location");
        builder.HasKey(d => d.Id);
        builder.Property(d => d.Id).HasColumnName("id").ValueGeneratedOnAdd();
		builder.Property(d => d.Name).HasColumnName("name").HasMaxLength(50).IsRequired();
		builder.Property(d => d.Address).HasColumnName("address").HasMaxLength(100);
		builder.Property(d => d.NumberOfSeats).HasColumnName("number_of_seats");
        builder.HasIndex(v => v.Name).IsUnique();
                    
            
        
    }
}