using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Global;
public class VehicleStatusMap : IEntityTypeConfiguration<VehicleStatus>
{
    public void Configure(EntityTypeBuilder<VehicleStatus> builder)
    {
        builder.ToTable("vehicle_status");
        builder.HasKey(vs => vs.Id);
        builder.Property(vs => vs.Id).HasColumnName("id").ValueGeneratedOnAdd();
        builder.Property(vs => vs.Name).HasColumnName("name").HasMaxLength(20).IsRequired();
        builder.HasIndex(vs => vs.Name).IsUnique();
    }
}