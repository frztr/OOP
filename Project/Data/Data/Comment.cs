using System.ComponentModel.DataAnnotations;
public class Comment{
    [Required]
	public long Id { get;set; }
	public long PostId { get;set; }
	public Post Post {get;set;}
	public long UserId { get;set; }
	public User User {get;set;}
	public long? ParentCommentId { get;set; }
	public Comment ParentCommentComment {get;set;}
	[StringLength(512)]
	public string Content { get;set; }
	public DateTime? CreatedAt { get;set; }
	public DateTime? UpdatedAt { get;set; }
	public ICollection<Comment> Comments { get;set; }
	public ICollection<CommentLike> CommentLikes { get;set; }
}