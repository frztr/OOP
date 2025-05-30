
namespace Global;
public class FriendshipsRepositoryDto
{
    public long Id { get; set; }
	public long User1Id { get; set; }
	public long User2Id { get; set; }
	public short FriendshipsStatusId { get; set; }
	public DateTime? CreatedAt { get; set; }
	public DateTime? UpdatedAt { get; set; }
}