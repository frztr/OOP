using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Global;
public class CommentLikeMap : IEntityTypeConfiguration<CommentLike>
{
    public void Configure(EntityTypeBuilder<CommentLike> builder)
    {
        builder.ToTable("comment_like");
        builder.HasKey(d => d.Id);
        builder.Property(d => d.CommentId).HasColumnName("comment_id").IsRequired();
		builder.Property(d => d.UserId).HasColumnName("user_id").IsRequired();
		builder.Property(d => d.CreatedAt).HasColumnName("created_at");
        
                    
        builder.HasOne(d => d.Comment)
                .WithMany(e => e.CommentLikes)
                .HasForeignKey(d => d.CommentId);

		builder.HasOne(d => d.User)
                .WithMany(e => e.CommentLikes)
                .HasForeignKey(d => d.UserId);    
        
    }
}