using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Global;
public class VehicleDocumentMap : IEntityTypeConfiguration<VehicleDocument>
{
    public void Configure(EntityTypeBuilder<VehicleDocument> builder)
    {
        builder.ToTable("vehicle_document");
        builder.HasKey(d => d.Id);
        builder.Property(d => d.Id).HasColumnName("id").ValueGeneratedOnAdd();
		builder.Property(d => d.DoctypeId).HasColumnName("doctype_id").IsRequired();
		builder.Property(d => d.Src).HasColumnName("src").HasMaxLength(255).IsRequired();
		builder.Property(d => d.VehicleId).HasColumnName("vehicle_id").IsRequired();
        builder.HasIndex(v => v.Src).IsUnique();
                    
        builder.HasOne(d => d.DocumentType)
                .WithMany(e => e.VehicleDocuments)
                .HasForeignKey(d => d.DoctypeId);

		builder.HasOne(d => d.Vehicle)
                .WithMany(e => e.VehicleDocuments)
                .HasForeignKey(d => d.VehicleId);    
        
    }
}