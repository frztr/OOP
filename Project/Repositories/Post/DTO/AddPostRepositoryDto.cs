
using System.ComponentModel.DataAnnotations;
namespace Global;
public class AddPostRepositoryDto
{
	[Required]
	public long Id { get; set; }
	[Required]
	public long UserId { get; set; }
	[Required]
	[StringLength(12004)]
	public string Content { get; set; }
	public DateTime? CreatedAt { get; set; }
	public DateTime? UpdatedAt { get; set; }
}