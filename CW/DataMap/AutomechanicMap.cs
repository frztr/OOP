using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Global;
public class AutomechanicMap : IEntityTypeConfiguration<Automechanic>
{
    public void Configure(EntityTypeBuilder<Automechanic> builder)
    {
        builder.ToTable("automechanic");
        builder.HasKey(d => d.UserId);
        builder.Property(d => d.UserId).HasColumnName("user_id");
		builder.Property(d => d.Qualification).HasColumnName("qualification").HasMaxLength(30).IsRequired();
        
                    
        builder.HasOne(d => d.User)
                .WithOne(e => e.Automechanic)
                .HasForeignKey<Automechanic>(d => d.UserId);    
        
    }
}