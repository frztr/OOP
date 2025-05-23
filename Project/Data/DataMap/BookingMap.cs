using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Global;
public class BookingMap : IEntityTypeConfiguration<Booking>
{
    public void Configure(EntityTypeBuilder<Booking> builder)
    {
        builder.ToTable("booking");
        builder.HasKey(d => d.Id);
        builder.Property(d => d.UserId).HasColumnName("user_id").IsRequired();
		builder.Property(d => d.EventId).HasColumnName("event_id").IsRequired();
		builder.Property(d => d.BookingDate).HasColumnName("booking_date").IsRequired();
		builder.Property(d => d.BookingStatusId).HasColumnName("booking_status_id");
		builder.Property(d => d.NumberOfSeats).HasColumnName("number_of_seats");
        
                    
        builder.HasOne(d => d.User)
                .WithMany(e => e.Bookings)
                .HasForeignKey(d => d.UserId);

		builder.HasOne(d => d.Event)
                .WithMany(e => e.Bookings)
                .HasForeignKey(d => d.EventId);

		builder.HasOne(d => d.BookingStatus)
                .WithMany(e => e.Bookings)
                .HasForeignKey(d => d.BookingStatusId);    
        
    }
}