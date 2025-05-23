using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Global;
public class PaymentMap : IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> builder)
    {
        builder.ToTable("payment");
        builder.HasKey(d => d.Id);
        builder.Property(d => d.BookingId).HasColumnName("booking_id").IsRequired();
		builder.Property(d => d.Amount).HasColumnName("amount").IsRequired();
		builder.Property(d => d.PaymentDate).HasColumnName("payment_date").IsRequired();
		builder.Property(d => d.PaymentMethodId).HasColumnName("payment_method_id").IsRequired();
		builder.Property(d => d.StatusId).HasColumnName("status_id").IsRequired();
        
                    
        builder.HasOne(d => d.Booking)
                .WithMany(e => e.Payments)
                .HasForeignKey(d => d.BookingId);

		builder.HasOne(d => d.PaymentMethod)
                .WithMany(e => e.Payments)
                .HasForeignKey(d => d.PaymentMethodId);

		builder.HasOne(d => d.PaymentStatus)
                .WithMany(e => e.Payments)
                .HasForeignKey(d => d.StatusId);    
        
    }
}