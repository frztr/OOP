using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Global;
public class RepairConsumedSparePartMap : IEntityTypeConfiguration<RepairConsumedSparePart>
{
    public void Configure(EntityTypeBuilder<RepairConsumedSparePart> builder)
    {
        builder.ToTable("repair_consumed_spare_part");
        builder.HasKey(d => d.Id);
        builder.Property(d => d.Id).HasColumnName("id").ValueGeneratedOnAdd();
		builder.Property(d => d.RepairId).HasColumnName("repair_id").IsRequired();
		builder.Property(d => d.SparePartId).HasColumnName("spare_part_id").IsRequired();
		builder.Property(d => d.PartCount).HasColumnName("part_count").IsRequired();
        
                    
        builder.HasOne(d => d.RepairHistory)
                .WithMany(e => e.RepairConsumedSpareParts)
                .HasForeignKey(d => d.RepairId);

		builder.HasOne(d => d.SparePart)
                .WithMany(e => e.RepairConsumedSpareParts)
                .HasForeignKey(d => d.SparePartId);    
        
    }
}