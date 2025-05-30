
namespace Global;
public interface ICommentService
{
    public Task<CommentListServiceDto> GetAllAsync(CommentQueryServiceDto queryDto);

    public Task<CommentServiceDto> GetByIdAsync(long id);

    public Task<CommentServiceDto> AddAsync(AddCommentServiceDto addDto);

    public Task DeleteAsync(long id);

    public Task UpdateAsync(UpdateCommentServiceDto updateDto);
}