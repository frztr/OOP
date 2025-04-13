using System.ComponentModel.DataAnnotations;
public class Driver{
    [Required]
	public short UserId { get;set; }
	public User User {get;set;}
	public long DriverLicense { get;set; }
	public short Experience { get;set; }
	public ICollection<RefuelingHistory> RefuelingHistories { get;set; }
}