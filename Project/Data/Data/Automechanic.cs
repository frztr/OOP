using System.ComponentModel.DataAnnotations;
public class Automechanic{
    [Required]
	public short UserId { get;set; }
	public User User {get;set;}
	[StringLength(30)]
	public string Qualification { get;set; }
	public ICollection<RepairHistory> RepairHistories { get;set; }
	public ICollection<MaintenanceHistory> MaintenanceHistories { get;set; }
}