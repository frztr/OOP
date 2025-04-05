using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Global;
public class VehicleDocumentMap : IEntityTypeConfiguration<VehicleDocument>
{
    public void Configure(EntityTypeBuilder<VehicleDocument> builder)
    {
        builder.ToTable("vehicle_document");
        builder.HasKey(vd => vd.Id);
        builder.Property(vd => vd.Id).HasColumnName("id").ValueGeneratedOnAdd();
        builder.Property(vd => vd.DocTypeId).HasColumnName("doctype_id").IsRequired();
        builder.Property(vd => vd.Src).HasColumnName("src").HasMaxLength(255).IsRequired();
        builder.Property(vd => vd.VehicleId).HasColumnName("vehicle_id").IsRequired();
        builder.HasIndex(vd => vd.Src).IsUnique();
        
        builder.HasOne(vd => vd.DocumentType)
            .WithMany(dt => dt.VehicleDocuments)
            .HasForeignKey(vd => vd.DocTypeId);
            
        builder.HasOne(vd => vd.Vehicle)
            .WithMany(v => v.Documents)
            .HasForeignKey(vd => vd.VehicleId);
    }
}