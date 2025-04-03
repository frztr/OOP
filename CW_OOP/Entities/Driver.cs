using System.ComponentModel.DataAnnotations.Schema;
namespace Global;
public class Driver : IEntity<short>
{
    public short EmployeeId { get; set; }
    public long DriverLicense { get; set; }
    public short Experience { get; set; }
    
    public Employee Employee { get; set; }
    public ICollection<RefuelingHistory> RefuelingHistories { get; set; }

    [NotMapped]
    public short Id { get => EmployeeId; set => EmployeeId = value; }
}