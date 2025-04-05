using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Global;
public class SparePartMap : IEntityTypeConfiguration<SparePart>
{
    public void Configure(EntityTypeBuilder<SparePart> builder)
    {
        builder.ToTable("spare_part");
        builder.HasKey(sp => sp.Id);
        builder.Property(sp => sp.Id).HasColumnName("id").ValueGeneratedOnAdd();
        builder.Property(sp => sp.Name).HasColumnName("name").HasMaxLength(100).IsRequired();
        builder.Property(sp => sp.CountLeft).HasColumnName("count_left").HasDefaultValue(0);
        builder.HasIndex(sp => sp.Name).IsUnique();
    }
}