
using System.ComponentModel.DataAnnotations;
namespace Global;
public class AddDocumentTypeControllerDto
{
	[Required]
	[StringLength(20)]
	public string Name { get; set; }
}