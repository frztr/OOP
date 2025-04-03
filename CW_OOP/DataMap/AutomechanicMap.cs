using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Global;
public class AutomechanicMap : IEntityTypeConfiguration<Automechanic>
{
    public void Configure(EntityTypeBuilder<Automechanic> builder)
    {
        builder.ToTable("automechanic");
        builder.HasKey(a => a.EmployeeId);
        builder.Property(a => a.EmployeeId).HasColumnName("employee_id");
        builder.Property(a => a.Qualification).HasColumnName("qualification").HasMaxLength(30).IsRequired();
        
        builder.HasOne(a => a.Employee)
            .WithOne(e => e.Automechanic)
            .HasForeignKey<Automechanic>(a => a.EmployeeId);
    }
}