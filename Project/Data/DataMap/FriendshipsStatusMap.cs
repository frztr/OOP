using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Global;
public class FriendshipsStatusMap : IEntityTypeConfiguration<FriendshipsStatus>
{
    public void Configure(EntityTypeBuilder<FriendshipsStatus> builder)
    {
        builder.ToTable("friendships_status");
        builder.HasKey(d => d.Id);
        builder.Property(d => d.Id).HasColumnName("id").ValueGeneratedOnAdd();
		builder.Property(d => d.Name).HasColumnName("name").HasMaxLength(10).IsRequired();
        
                    
            
        
    }
}