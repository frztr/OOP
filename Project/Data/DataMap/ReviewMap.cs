using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Global;
public class ReviewMap : IEntityTypeConfiguration<Review>
{
    public void Configure(EntityTypeBuilder<Review> builder)
    {
        builder.ToTable("review");
        builder.HasKey(d => d.Id);
        builder.Property(d => d.UserId).HasColumnName("user_id").IsRequired();
		builder.Property(d => d.EventId).HasColumnName("event_id").IsRequired();
		builder.Property(d => d.Rating).HasColumnName("rating").IsRequired();
		builder.Property(d => d.Comment).HasColumnName("comment").HasMaxLength(500);
		builder.Property(d => d.ReviewDate).HasColumnName("review_date");
        
                    
        builder.HasOne(d => d.User)
                .WithMany(e => e.Reviews)
                .HasForeignKey(d => d.UserId);

		builder.HasOne(d => d.Event)
                .WithMany(e => e.Reviews)
                .HasForeignKey(d => d.EventId);    
        
    }
}