using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Global;
public class UserMap : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("user");
        builder.HasKey(d => d.Id);
        builder.Property(d => d.FirstName).HasColumnName("first_name").HasMaxLength(50).IsRequired();
		builder.Property(d => d.LastName).HasColumnName("last_name").HasMaxLength(50).IsRequired();
		builder.Property(d => d.Patronymic).HasColumnName("patronymic").HasMaxLength(20);
		builder.Property(d => d.Email).HasColumnName("email").HasMaxLength(100).IsRequired();
		builder.Property(d => d.Phone).HasColumnName("phone").HasMaxLength(20).IsRequired();
		builder.Property(d => d.PasswordHash).HasColumnName("password_hash").HasMaxLength(32).IsRequired();
		builder.Property(d => d.RoleId).HasColumnName("role_id");
        builder.HasIndex(v => v.Email).IsUnique();
		builder.HasIndex(v => v.Phone).IsUnique();
                    
        builder.HasOne(d => d.Role)
                .WithMany(e => e.Users)
                .HasForeignKey(d => d.RoleId);    
        
    }
}