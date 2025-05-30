using System.ComponentModel.DataAnnotations;
public class Post{
    [Required]
	public long Id { get;set; }
	public long UserId { get;set; }
	public User User {get;set;}
	[StringLength(12004)]
	public string Content { get;set; }
	public DateTime? CreatedAt { get;set; }
	public DateTime? UpdatedAt { get;set; }
	public ICollection<Comment> Comments { get;set; }
	public ICollection<PostLike> PostLikes { get;set; }
}