using System.ComponentModel.DataAnnotations;
public class Friendships{
    [Required]
	public long Id { get;set; }
	public long User1Id { get;set; }
	public User User1User {get;set;}
	public long User2Id { get;set; }
	public User User2User {get;set;}
	public short FriendshipsStatusId { get;set; }
	public FriendshipsStatus FriendshipsStatus {get;set;}
	public DateTime? CreatedAt { get;set; }
	public DateTime? UpdatedAt { get;set; }
}