
namespace Global;
public interface IPostLikeService
{
    public Task<PostLikeListServiceDto> GetAllAsync(PostLikeQueryServiceDto queryDto);

    public Task<PostLikeServiceDto> GetByIdAsync(long id);

    public Task<PostLikeServiceDto> AddAsync(AddPostLikeServiceDto addDto);

    public Task DeleteAsync(long id);

    public Task UpdateAsync(UpdatePostLikeServiceDto updateDto);
}