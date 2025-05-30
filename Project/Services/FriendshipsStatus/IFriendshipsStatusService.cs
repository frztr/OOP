
namespace Global;
public interface IFriendshipsStatusService
{
    public Task<FriendshipsStatusListServiceDto> GetAllAsync(FriendshipsStatusQueryServiceDto queryDto);

    public Task<FriendshipsStatusServiceDto> GetByIdAsync(short id);

    public Task<FriendshipsStatusServiceDto> AddAsync(AddFriendshipsStatusServiceDto addDto);

    public Task DeleteAsync(short id);

    public Task UpdateAsync(UpdateFriendshipsStatusServiceDto updateDto);
}