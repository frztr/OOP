using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Global;
public class DriverMap : IEntityTypeConfiguration<Driver>
{
    public void Configure(EntityTypeBuilder<Driver> builder)
    {
        builder.ToTable("driver");
        builder.HasKey(d => d.EmployeeId);
        builder.Property(d => d.EmployeeId).HasColumnName("employee_id");
        builder.Property(d => d.DriverLicense).HasColumnName("driver_license").IsRequired();
        builder.Property(d => d.Experience).HasColumnName("experience").IsRequired();
        builder.HasIndex(d => d.DriverLicense).IsUnique();
        
        builder.HasOne(d => d.Employee)
            .WithOne(e => e.Driver)
            .HasForeignKey<Driver>(d => d.EmployeeId);
    }
}
