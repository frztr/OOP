using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Global;
public class PostMap : IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        builder.ToTable("post");
        builder.HasKey(d => d.Id);
        builder.Property(d => d.UserId).HasColumnName("user_id").IsRequired();
		builder.Property(d => d.Content).HasColumnName("content").HasMaxLength(12004).IsRequired();
		builder.Property(d => d.CreatedAt).HasColumnName("created_at");
		builder.Property(d => d.UpdatedAt).HasColumnName("updated_at");
        
                    
        builder.HasOne(d => d.User)
                .WithMany(e => e.Posts)
                .HasForeignKey(d => d.UserId);    
        
    }
}