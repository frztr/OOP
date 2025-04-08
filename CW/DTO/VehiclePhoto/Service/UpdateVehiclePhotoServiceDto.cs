
using System.ComponentModel.DataAnnotations;
namespace Global;
public class UpdateVehiclePhotoServiceDto
{
    [Required]
    	public int Id { get; set; }
    
    	[StringLength(255)]
	public string Src { get; set; }
		public int VehicleId { get; set; }
}