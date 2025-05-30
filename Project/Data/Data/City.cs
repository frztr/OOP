using System.ComponentModel.DataAnnotations;
public class City{
    [Required]
	public int Id { get;set; }
	[StringLength(50)]
	public string Name { get;set; }
	public short CountryId { get;set; }
	public Country Country {get;set;}
	public ICollection<User> Users { get;set; }
}