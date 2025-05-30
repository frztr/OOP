
namespace Global;
public interface IPostService
{
    public Task<PostListServiceDto> GetAllAsync(PostQueryServiceDto queryDto);

    public Task<PostServiceDto> GetByIdAsync(long id);

    public Task<PostServiceDto> AddAsync(AddPostServiceDto addDto);

    public Task DeleteAsync(long id);

    public Task UpdateAsync(UpdatePostServiceDto updateDto);
}