using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Global;
public class EventMap : IEntityTypeConfiguration<Event>
{
    public void Configure(EntityTypeBuilder<Event> builder)
    {
        builder.ToTable("event");
        builder.HasKey(d => d.Id);
        builder.Property(d => d.Id).HasColumnName("id").ValueGeneratedOnAdd();
		builder.Property(d => d.Title).HasColumnName("title").HasMaxLength(50).IsRequired();
		builder.Property(d => d.Description).HasColumnName("description").HasMaxLength(300).IsRequired();
		builder.Property(d => d.LocationId).HasColumnName("location_id").IsRequired();
		builder.Property(d => d.StartTime).HasColumnName("start_time").IsRequired();
		builder.Property(d => d.EndTime).HasColumnName("end_time").IsRequired();
		builder.Property(d => d.CreatedBy).HasColumnName("created_by").IsRequired();
		builder.Property(d => d.EventCategoryId).HasColumnName("event_category_id").IsRequired();
        builder.HasIndex(v => v.Title).IsUnique();
                    
        builder.HasOne(d => d.Location)
                .WithMany(e => e.Events)
                .HasForeignKey(d => d.LocationId);

		builder.HasOne(d => d.User)
                .WithMany(e => e.Events)
                .HasForeignKey(d => d.CreatedBy);

		builder.HasOne(d => d.EventCategory)
                .WithMany(e => e.Events)
                .HasForeignKey(d => d.EventCategoryId);    
        
    }
}