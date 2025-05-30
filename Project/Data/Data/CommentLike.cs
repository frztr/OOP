using System.ComponentModel.DataAnnotations;
public class CommentLike{
    [Required]
	public long Id { get;set; }
	public long CommentId { get;set; }
	public Comment Comment {get;set;}
	public long UserId { get;set; }
	public User User {get;set;}
	public DateTime? CreatedAt { get;set; }
}