using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Global;
public class CommentMap : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.ToTable("comment");
        builder.HasKey(d => d.Id);
        builder.Property(d => d.PostId).HasColumnName("post_id").IsRequired();
		builder.Property(d => d.UserId).HasColumnName("user_id").IsRequired();
		builder.Property(d => d.ParentCommentId).HasColumnName("parent_comment_id");
		builder.Property(d => d.Content).HasColumnName("content").HasMaxLength(512).IsRequired();
		builder.Property(d => d.CreatedAt).HasColumnName("created_at");
		builder.Property(d => d.UpdatedAt).HasColumnName("updated_at");
        
                    
        builder.HasOne(d => d.Post)
                .WithMany(e => e.Comments)
                .HasForeignKey(d => d.PostId);

		builder.HasOne(d => d.User)
                .WithMany(e => e.Comments)
                .HasForeignKey(d => d.UserId);

		builder.HasOne(d => d.ParentCommentComment)
                .WithMany(e => e.Comments)
                .HasForeignKey(d => d.ParentCommentId);    
        
    }
}