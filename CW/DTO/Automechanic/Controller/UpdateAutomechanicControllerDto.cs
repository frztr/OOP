
using System.ComponentModel.DataAnnotations;
namespace Global;
public class UpdateAutomechanicControllerDto
{
    [Required]
    	public short UserId { get; set; }
    
    	[StringLength(30)]
	public string Qualification { get; set; }
}