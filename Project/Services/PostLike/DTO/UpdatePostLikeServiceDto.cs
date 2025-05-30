
using System.ComponentModel.DataAnnotations;
namespace Global;
public class UpdatePostLikeServiceDto
{
    [Required]
	public long Id { get; set; }
	public long? PostId { get; set; }
	public long? UserId { get; set; }
	public DateTime? CreatedAt { get; set; }
}