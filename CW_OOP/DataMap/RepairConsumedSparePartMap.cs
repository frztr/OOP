using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Global;
public class RepairConsumedSparePartMap : IEntityTypeConfiguration<RepairConsumedSparePart>
{
    public void Configure(EntityTypeBuilder<RepairConsumedSparePart> builder)
    {
        builder.ToTable("repair_consumed_spare_part");
        builder.HasKey(rcsp => rcsp.Id);
        builder.Property(rcsp => rcsp.Id).HasColumnName("id").ValueGeneratedOnAdd();
        builder.Property(rcsp => rcsp.RepairId).HasColumnName("repair_id").IsRequired();
        builder.Property(rcsp => rcsp.SparePartId).HasColumnName("spare_part_id").IsRequired();
        builder.Property(rcsp => rcsp.PartCount).HasColumnName("part_count").IsRequired();
        
        builder.HasOne(rcsp => rcsp.Repair)
            .WithMany(r => r.ConsumedSpareParts)
            .HasForeignKey(rcsp => rcsp.RepairId);
            
        builder.HasOne(rcsp => rcsp.SparePart)
            .WithMany(sp => sp.RepairConsumptions)
            .HasForeignKey(rcsp => rcsp.SparePartId);
    }
}