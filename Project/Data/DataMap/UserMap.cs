using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Global;
public class UserMap : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("user");
        builder.HasKey(d => d.Id);
        builder.Property(d => d.Login).HasColumnName("login").HasMaxLength(20).IsRequired();
		builder.Property(d => d.Email).HasColumnName("email").HasMaxLength(40).IsRequired();
		builder.Property(d => d.PasswordHash).HasColumnName("password_hash").HasMaxLength(32).IsRequired();
		builder.Property(d => d.Firstname).HasColumnName("firstname").HasMaxLength(50);
		builder.Property(d => d.Lastname).HasColumnName("lastname").HasMaxLength(50);
		builder.Property(d => d.BirthDate).HasColumnName("birth_date");
		builder.Property(d => d.Bio).HasColumnName("bio").HasMaxLength(12004);
		builder.Property(d => d.CityId).HasColumnName("city_id");
		builder.Property(d => d.RoleId).HasColumnName("role_id").IsRequired();
		builder.Property(d => d.WebsiteUrl).HasColumnName("website_url").HasMaxLength(255);
		builder.Property(d => d.AvatarUrl).HasColumnName("avatar_url").HasMaxLength(300);
		builder.Property(d => d.RegistrationDate).HasColumnName("registration_date");
		builder.Property(d => d.LastLogin).HasColumnName("last_login");
		builder.Property(d => d.IsActive).HasColumnName("is_active");
		builder.Property(d => d.Gender).HasColumnName("gender");
        
                    
        builder.HasOne(d => d.City)
                .WithMany(e => e.Users)
                .HasForeignKey(d => d.CityId);

		builder.HasOne(d => d.Role)
                .WithMany(e => e.Users)
                .HasForeignKey(d => d.RoleId);    
        
    }
}