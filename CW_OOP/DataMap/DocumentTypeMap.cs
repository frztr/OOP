using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Global;
public class DocumentTypeMap : IEntityTypeConfiguration<DocumentType>
{
    public void Configure(EntityTypeBuilder<DocumentType> builder)
    {
        builder.ToTable("document_type");
        builder.HasKey(dt => dt.Id);
        builder.Property(dt => dt.Id).HasColumnName("id").ValueGeneratedOnAdd();
        builder.Property(dt => dt.Name).HasColumnName("name").HasMaxLength(20).IsRequired();
        builder.HasIndex(dt => dt.Name).IsUnique();
    }
}