
namespace Global;
public interface IPostRepository
{
    public Task<PostListRepositoryDto> GetAllAsync(PostQueryRepositoryDto queryDto);

    public Task<PostRepositoryDto> GetByIdAsync(long id);

    public Task<PostRepositoryDto> AddAsync(AddPostRepositoryDto addDto);

    public Task DeleteAsync(long id);

    public Task UpdateAsync(UpdatePostRepositoryDto updateDto);
}