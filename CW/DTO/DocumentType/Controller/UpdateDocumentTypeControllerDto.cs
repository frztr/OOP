
using System.ComponentModel.DataAnnotations;
namespace Global;
public class UpdateDocumentTypeControllerDto
{
    [Required]
    	public short Id { get; set; }
    
    	[StringLength(20)]
	public string Name { get; set; }
}