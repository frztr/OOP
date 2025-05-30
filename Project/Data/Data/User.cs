using System.ComponentModel.DataAnnotations;
public class User{
    [Required]
	public long Id { get;set; }
	[StringLength(20)]
	public string Login { get;set; }
	[StringLength(40)]
	public string Email { get;set; }
	[StringLength(32)]
	public string PasswordHash { get;set; }
	[StringLength(50)]
	public string? Firstname { get;set; }
	[StringLength(50)]
	public string? Lastname { get;set; }
	public DateTime? BirthDate { get;set; }
	[StringLength(12004)]
	public string? Bio { get;set; }
	public int? CityId { get;set; }
	public City City {get;set;}
	public short RoleId { get;set; }
	public Role Role {get;set;}
	[StringLength(255)]
	public string? WebsiteUrl { get;set; }
	[StringLength(300)]
	public string? AvatarUrl { get;set; }
	public DateTime? RegistrationDate { get;set; }
	public DateTime? LastLogin { get;set; }
	public bool IsActive { get;set; }
	public bool Gender { get;set; }
	public ICollection<Post> Posts { get;set; }
	public ICollection<Friendships> User1Friendshipss { get;set; }
	public ICollection<Friendships> User2Friendshipss { get;set; }
	public ICollection<Comment> Comments { get;set; }
	public ICollection<PostLike> PostLikes { get;set; }
	public ICollection<CommentLike> CommentLikes { get;set; }
	public ICollection<Message> SenderMessages { get;set; }
	public ICollection<Message> ReceiverMessages { get;set; }
}