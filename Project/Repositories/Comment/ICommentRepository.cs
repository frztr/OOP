
namespace Global;
public interface ICommentRepository
{
    public Task<CommentListRepositoryDto> GetAllAsync(CommentQueryRepositoryDto queryDto);

    public Task<CommentRepositoryDto> GetByIdAsync(long id);

    public Task<CommentRepositoryDto> AddAsync(AddCommentRepositoryDto addDto);

    public Task DeleteAsync(long id);

    public Task UpdateAsync(UpdateCommentRepositoryDto updateDto);
}