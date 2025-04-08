using System.ComponentModel.DataAnnotations.Schema;
namespace Global;
public class Driver
{
    public short UserId { get; set; }
    public long DriverLicense { get; set; }
    public short Experience { get; set; }
    
    public User User { get; set; }
    public ICollection<RefuelingHistory> RefuelingHistories { get; set; }
}