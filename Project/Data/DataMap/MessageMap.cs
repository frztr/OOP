using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Global;
public class MessageMap : IEntityTypeConfiguration<Message>
{
    public void Configure(EntityTypeBuilder<Message> builder)
    {
        builder.ToTable("message");
        builder.HasKey(d => d.Id);
        builder.Property(d => d.SenderId).HasColumnName("sender_id").IsRequired();
		builder.Property(d => d.ReceiverId).HasColumnName("receiver_id").IsRequired();
		builder.Property(d => d.Content).HasColumnName("content").HasMaxLength(512).IsRequired();
		builder.Property(d => d.SentAt).HasColumnName("sent_at");
		builder.Property(d => d.ReplyTo).HasColumnName("reply_to");
        
                    
        builder.HasOne(d => d.SenderUser)
                .WithMany(e => e.SenderMessages)
                .HasForeignKey(d => d.SenderId);

		builder.HasOne(d => d.ReceiverUser)
                .WithMany(e => e.ReceiverMessages)
                .HasForeignKey(d => d.ReceiverId);

		builder.HasOne(d => d.ReplyToMessage)
                .WithMany(e => e.Messages)
                .HasForeignKey(d => d.ReplyTo);    
        
    }
}