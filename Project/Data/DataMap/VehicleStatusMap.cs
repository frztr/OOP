using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Global;
public class VehicleStatusMap : IEntityTypeConfiguration<VehicleStatus>
{
    public void Configure(EntityTypeBuilder<VehicleStatus> builder)
    {
        builder.ToTable("vehicle_status");
        builder.HasKey(d => d.Id);
        builder.Property(d => d.Id).HasColumnName("id").ValueGeneratedOnAdd();
		builder.Property(d => d.Name).HasColumnName("name").HasMaxLength(20).IsRequired();
        builder.HasIndex(v => v.Name).IsUnique();
                    
            
        
    }
}