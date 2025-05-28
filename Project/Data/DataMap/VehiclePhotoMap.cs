using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Global;
public class VehiclePhotoMap : IEntityTypeConfiguration<VehiclePhoto>
{
    public void Configure(EntityTypeBuilder<VehiclePhoto> builder)
    {
        builder.ToTable("vehicle_photo");
        builder.HasKey(d => d.Id);
        builder.Property(d => d.Id).HasColumnName("id").ValueGeneratedOnAdd();
		builder.Property(d => d.Src).HasColumnName("src").HasMaxLength(255).IsRequired();
		builder.Property(d => d.VehicleId).HasColumnName("vehicle_id").IsRequired();
        builder.HasIndex(v => v.Src).IsUnique();
                    
        builder.HasOne(d => d.Vehicle)
                .WithMany(e => e.VehiclePhotos)
                .HasForeignKey(d => d.VehicleId);    
        
    }
}