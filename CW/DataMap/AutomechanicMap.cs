using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Global;
public class AutomechanicMap : IEntityTypeConfiguration<Automechanic>
{
    public void Configure(EntityTypeBuilder<Automechanic> builder)
    {
        builder.ToTable("automechanic");
        builder.HasKey(a => a.UserId);
        builder.Property(a => a.UserId).HasColumnName("user_id");
        builder.Property(a => a.Qualification).HasColumnName("qualification").HasMaxLength(30).IsRequired();
        
        builder.HasOne(a => a.User)
            .WithOne(e => e.Automechanic)
            .HasForeignKey<Automechanic>(a => a.UserId);
    }
}