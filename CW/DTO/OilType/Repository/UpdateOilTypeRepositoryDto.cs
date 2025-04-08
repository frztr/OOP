
using System.ComponentModel.DataAnnotations;
namespace Global;
public class UpdateOilTypeRepositoryDto
{
    [Required]
    	public short Id { get; set; }
    
    	[StringLength(10)]
	public string Name { get; set; }
		public short FuelTypeId { get; set; }
}