using System.ComponentModel.DataAnnotations.Schema;
namespace Global;
public class Employee : IEntity<short>
{
    public short UserId { get; set; }
    public string Fio { get; set; }
    
    public User User { get; set; }
    public Automechanic Automechanic { get; set; }
    public Driver Driver { get; set; }
    public ICollection<MaintenanceHistory> MaintenanceHistories { get; set; }
    public ICollection<RefuelingHistory> RefuelingHistories { get; set; }
    [NotMapped]
    public short Id { get => UserId; set => UserId = value; }
}