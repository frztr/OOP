using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Global;
public class MaintenanceTypeMap : IEntityTypeConfiguration<MaintenanceType>
{
    public void Configure(EntityTypeBuilder<MaintenanceType> builder)
    {
        builder.ToTable("maintenance_type");
        builder.HasKey(mt => mt.Id);
        builder.Property(mt => mt.Id).HasColumnName("id").ValueGeneratedOnAdd();
        builder.Property(mt => mt.Name).HasColumnName("name").HasMaxLength(30).IsRequired();
        builder.HasIndex(mt => mt.Name).IsUnique();
    }
}