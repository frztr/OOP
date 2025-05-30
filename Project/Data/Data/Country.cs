using System.ComponentModel.DataAnnotations;
public class Country{
    [Required]
	public short Id { get;set; }
	[StringLength(50)]
	public string Name { get;set; }
	public ICollection<City> Cities { get;set; }
}