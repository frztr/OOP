using System.ComponentModel.DataAnnotations;
public class PostLike{
    [Required]
	public long Id { get;set; }
	public long PostId { get;set; }
	public Post Post {get;set;}
	public long UserId { get;set; }
	public User User {get;set;}
	public DateTime? CreatedAt { get;set; }
}