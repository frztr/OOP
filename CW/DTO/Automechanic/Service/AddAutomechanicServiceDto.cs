
using System.ComponentModel.DataAnnotations;
namespace Global;
public class AddAutomechanicServiceDto
{
    [Required]
	public short UserId { get; set; }
	[Required]
	[StringLength(30)]
	public string Qualification { get; set; }
}