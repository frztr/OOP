
namespace Global;
public interface IPostLikeRepository
{
    public Task<PostLikeListRepositoryDto> GetAllAsync(PostLikeQueryRepositoryDto queryDto);

    public Task<PostLikeRepositoryDto> GetByIdAsync(long id);

    public Task<PostLikeRepositoryDto> AddAsync(AddPostLikeRepositoryDto addDto);

    public Task DeleteAsync(long id);

    public Task UpdateAsync(UpdatePostLikeRepositoryDto updateDto);
}