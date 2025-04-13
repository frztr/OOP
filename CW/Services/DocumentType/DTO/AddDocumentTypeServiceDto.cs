
using System.ComponentModel.DataAnnotations;
namespace Global;
public class AddDocumentTypeServiceDto
{
	[Required]
	[StringLength(20)]
	public string Name { get; set; }
}