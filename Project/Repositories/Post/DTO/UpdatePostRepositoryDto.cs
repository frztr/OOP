
using System.ComponentModel.DataAnnotations;
namespace Global;
public class UpdatePostRepositoryDto
{
    [Required]
	public long Id { get; set; }
	public long? UserId { get; set; }
	[StringLength(12004)]
	public string? Content { get; set; }
	public DateTime? CreatedAt { get; set; }
	public DateTime? UpdatedAt { get; set; }
}