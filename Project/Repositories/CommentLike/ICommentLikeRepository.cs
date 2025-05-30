
namespace Global;
public interface ICommentLikeRepository
{
    public Task<CommentLikeListRepositoryDto> GetAllAsync(CommentLikeQueryRepositoryDto queryDto);

    public Task<CommentLikeRepositoryDto> GetByIdAsync(long id);

    public Task<CommentLikeRepositoryDto> AddAsync(AddCommentLikeRepositoryDto addDto);

    public Task DeleteAsync(long id);

    public Task UpdateAsync(UpdateCommentLikeRepositoryDto updateDto);
}