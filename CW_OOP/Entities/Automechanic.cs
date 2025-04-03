using System.ComponentModel.DataAnnotations.Schema;
namespace Global;

public class Automechanic : IEntity<short>
{
    public short EmployeeId { get; set; }
    public string Qualification { get; set; }
    
    public Employee Employee { get; set; }
    public ICollection<RepairHistory> RepairHistories { get; set; }
    public ICollection<MaintenanceHistory> MaintenanceHistories { get; set; }

    [NotMapped]
    public short Id { get => EmployeeId; set => EmployeeId = value; }
}