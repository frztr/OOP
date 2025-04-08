
using System.ComponentModel.DataAnnotations;
namespace Global;
public class UpdateAutomechanicRepositoryDto
{
    [Required]
    	public short UserId { get; set; }
    
    	[StringLength(30)]
	public string Qualification { get; set; }
}