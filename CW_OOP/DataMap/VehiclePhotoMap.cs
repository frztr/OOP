using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Global;
public class VehiclePhotoMap : IEntityTypeConfiguration<VehiclePhoto>
{
    public void Configure(EntityTypeBuilder<VehiclePhoto> builder)
    {
        builder.ToTable("vehicle_photo");
        builder.HasKey(vp => vp.Id);
        builder.Property(vp => vp.Id).HasColumnName("id").ValueGeneratedOnAdd();
        builder.Property(vp => vp.Src).HasColumnName("src").HasMaxLength(255).IsRequired();
        builder.Property(vp => vp.VehicleId).HasColumnName("vehicle_id").IsRequired();
        builder.HasIndex(vp => vp.Src).IsUnique();
        
        builder.HasOne(vp => vp.Vehicle)
            .WithMany(v => v.Photos)
            .HasForeignKey(vp => vp.VehicleId);
    }
}