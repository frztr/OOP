using System.ComponentModel.DataAnnotations;
public class Role{
    [Required]
	public short Id { get;set; }
	[StringLength(30)]
	public string Name { get;set; }
	public ICollection<User> Users { get;set; }
}