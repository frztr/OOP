using System.ComponentModel.DataAnnotations.Schema;
namespace Global;

public class Automechanic
{
    public short UserId { get; set; }
    public string Qualification { get; set; }
    
    public User User { get; set; }
    public ICollection<RepairHistory> RepairHistories { get; set; }
    public ICollection<MaintenanceHistory> MaintenanceHistories { get; set; }
}