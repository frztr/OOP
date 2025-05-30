using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Global;
public class FriendshipsMap : IEntityTypeConfiguration<Friendships>
{
    public void Configure(EntityTypeBuilder<Friendships> builder)
    {
        builder.ToTable("friendships");
        builder.HasKey(d => d.Id);
        builder.Property(d => d.User1Id).HasColumnName("user1_id").IsRequired();
		builder.Property(d => d.User2Id).HasColumnName("user2_id").IsRequired();
		builder.Property(d => d.FriendshipsStatusId).HasColumnName("friendships_status_id").IsRequired();
		builder.Property(d => d.CreatedAt).HasColumnName("created_at");
		builder.Property(d => d.UpdatedAt).HasColumnName("updated_at");
        
                    
        builder.HasOne(d => d.User1User)
                .WithMany(e => e.User1Friendshipss)
                .HasForeignKey(d => d.User1Id);

		builder.HasOne(d => d.User2User)
                .WithMany(e => e.User2Friendshipss)
                .HasForeignKey(d => d.User2Id);

		builder.HasOne(d => d.FriendshipsStatus)
                .WithMany(e => e.Friendshipss)
                .HasForeignKey(d => d.FriendshipsStatusId);    
        
    }
}