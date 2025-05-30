
namespace Global;
public interface ICommentLikeService
{
    public Task<CommentLikeListServiceDto> GetAllAsync(CommentLikeQueryServiceDto queryDto);

    public Task<CommentLikeServiceDto> GetByIdAsync(long id);

    public Task<CommentLikeServiceDto> AddAsync(AddCommentLikeServiceDto addDto);

    public Task DeleteAsync(long id);

    public Task UpdateAsync(UpdateCommentLikeServiceDto updateDto);
}