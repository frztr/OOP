using System.ComponentModel.DataAnnotations;
public class Role{
    [Required]
	public short Id { get;set; }
	[StringLength(15)]
	public string Name { get;set; }
	public ICollection<User> Users { get;set; }
}