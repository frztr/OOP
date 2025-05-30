using System.ComponentModel.DataAnnotations;
public class Role{
    [Required]
	public short Id { get;set; }
	[StringLength(20)]
	public string Name { get;set; }
	[StringLength(100)]
	public string? Description { get;set; }
	public ICollection<User> Users { get;set; }
}