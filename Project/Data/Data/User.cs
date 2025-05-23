using System.ComponentModel.DataAnnotations;
public class User{
    [Required]
	public long Id { get;set; }
	[StringLength(50)]
	public string FirstName { get;set; }
	[StringLength(50)]
	public string LastName { get;set; }
	[StringLength(20)]
	public string? Patronymic { get;set; }
	[StringLength(100)]
	public string Email { get;set; }
	[StringLength(20)]
	public string Phone { get;set; }
	[StringLength(32)]
	public string PasswordHash { get;set; }
	public short? RoleId { get;set; }
	public Role Role {get;set;}
	public ICollection<Event> Events { get;set; }
	public ICollection<Booking> Bookings { get;set; }
	public ICollection<Review> Reviews { get;set; }
}