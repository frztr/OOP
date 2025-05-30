using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Global;
public class PostLikeMap : IEntityTypeConfiguration<PostLike>
{
    public void Configure(EntityTypeBuilder<PostLike> builder)
    {
        builder.ToTable("post_like");
        builder.HasKey(d => d.Id);
        builder.Property(d => d.PostId).HasColumnName("post_id").IsRequired();
		builder.Property(d => d.UserId).HasColumnName("user_id").IsRequired();
		builder.Property(d => d.CreatedAt).HasColumnName("created_at");
        
                    
        builder.HasOne(d => d.Post)
                .WithMany(e => e.PostLikes)
                .HasForeignKey(d => d.PostId);

		builder.HasOne(d => d.User)
                .WithMany(e => e.PostLikes)
                .HasForeignKey(d => d.UserId);    
        
    }
}