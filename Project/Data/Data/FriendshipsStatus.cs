using System.ComponentModel.DataAnnotations;
public class FriendshipsStatus{
    [Required]
	public short Id { get;set; }
	[StringLength(10)]
	public string Name { get;set; }
	public ICollection<Friendships> Friendshipss { get;set; }
}