using System.ComponentModel.DataAnnotations;
public class Message{
    [Required]
	public long Id { get;set; }
	public long SenderId { get;set; }
	public User SenderUser {get;set;}
	public long ReceiverId { get;set; }
	public User ReceiverUser {get;set;}
	[StringLength(512)]
	public string Content { get;set; }
	public DateTime? SentAt { get;set; }
	public long? ReplyTo { get;set; }
	public Message ReplyToMessage {get;set;}
	public ICollection<Message> Messages { get;set; }
}