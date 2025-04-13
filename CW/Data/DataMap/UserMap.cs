using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Global;
public class UserMap : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("user");
        builder.HasKey(d => d.Id);
        builder.Property(d => d.Id).HasColumnName("id").ValueGeneratedOnAdd();
		builder.Property(d => d.Login).HasColumnName("login").HasMaxLength(32).IsRequired();
		builder.Property(d => d.Fio).HasColumnName("fio").HasMaxLength(100).IsRequired();
		builder.Property(d => d.PasswordHash).HasColumnName("password_hash").HasMaxLength(128).IsRequired();
		builder.Property(d => d.RoleId).HasColumnName("role_id").IsRequired();
        builder.HasIndex(v => v.Login).IsUnique();
                    
        builder.HasOne(d => d.Role)
                .WithMany(e => e.Users)
                .HasForeignKey(d => d.RoleId);    
        
    }
}