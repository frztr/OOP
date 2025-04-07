
namespace Global;
public class UpdateAccountDto
{
    public int Id { get; set; }
    public int? FamilyId { get; set; }
	public string? Name { get; set; }
	public decimal? Balance { get; set; }
	public string? Currency { get; set; }
}