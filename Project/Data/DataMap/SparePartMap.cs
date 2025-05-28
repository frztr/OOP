using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Global;
public class SparePartMap : IEntityTypeConfiguration<SparePart>
{
    public void Configure(EntityTypeBuilder<SparePart> builder)
    {
        builder.ToTable("spare_part");
        builder.HasKey(d => d.Id);
        builder.Property(d => d.Id).HasColumnName("id").ValueGeneratedOnAdd();
		builder.Property(d => d.Name).HasColumnName("name").HasMaxLength(100).IsRequired();
		builder.Property(d => d.CountLeft).HasColumnName("count_left");
        builder.HasIndex(v => v.Name).IsUnique();
                    
            
        
    }
}