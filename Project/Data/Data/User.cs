using System.ComponentModel.DataAnnotations;
public class User{
    [Required]
	public short Id { get;set; }
	[StringLength(32)]
	public string Login { get;set; }
	[StringLength(100)]
	public string Fio { get;set; }
	[StringLength(128)]
	public string PasswordHash { get;set; }
	public short RoleId { get;set; }
	public Role Role {get;set;}
	public Automechanic? Automechanic { get;set; }
	public Driver? Driver { get;set; }
}