
using System.ComponentModel.DataAnnotations;
namespace Global;
public class AddUserServiceDto
{
    [Required]
	[StringLength(50)]
	public string FirstName { get; set; }
	[Required]
	[StringLength(50)]
	public string LastName { get; set; }
		[StringLength(20)]
	public string? Patronymic { get; set; }
	[Required]
	[StringLength(100)]
	public string Email { get; set; }
	[Required]
	[StringLength(20)]
	public string Phone { get; set; }
		public short? RoleId { get; set; }
    [Required]
    public string Password { get; set; }
}