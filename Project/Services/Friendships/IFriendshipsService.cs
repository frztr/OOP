
namespace Global;
public interface IFriendshipsService
{
    public Task<FriendshipsListServiceDto> GetAllAsync(FriendshipsQueryServiceDto queryDto);

    public Task<FriendshipsServiceDto> GetByIdAsync(long id);

    public Task<FriendshipsServiceDto> AddAsync(AddFriendshipsServiceDto addDto);

    public Task DeleteAsync(long id);

    public Task UpdateAsync(UpdateFriendshipsServiceDto updateDto);
}