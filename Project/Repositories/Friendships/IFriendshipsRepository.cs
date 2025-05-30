
namespace Global;
public interface IFriendshipsRepository
{
    public Task<FriendshipsListRepositoryDto> GetAllAsync(FriendshipsQueryRepositoryDto queryDto);

    public Task<FriendshipsRepositoryDto> GetByIdAsync(long id);

    public Task<FriendshipsRepositoryDto> AddAsync(AddFriendshipsRepositoryDto addDto);

    public Task DeleteAsync(long id);

    public Task UpdateAsync(UpdateFriendshipsRepositoryDto updateDto);
}