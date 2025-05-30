
namespace Global;
public interface IFriendshipsStatusRepository
{
    public Task<FriendshipsStatusListRepositoryDto> GetAllAsync(FriendshipsStatusQueryRepositoryDto queryDto);

    public Task<FriendshipsStatusRepositoryDto> GetByIdAsync(short id);

    public Task<FriendshipsStatusRepositoryDto> AddAsync(AddFriendshipsStatusRepositoryDto addDto);

    public Task DeleteAsync(short id);

    public Task UpdateAsync(UpdateFriendshipsStatusRepositoryDto updateDto);
}