
using System.ComponentModel.DataAnnotations;
namespace Global;
public class AddDocumentTypeRepositoryDto
{
    [Required]
	[StringLength(20)]
	public string Name { get; set; }
}