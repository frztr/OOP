
namespace Global;
public interface IReviewService
{
    public Task<ReviewListServiceDto> GetAllAsync(ReviewQueryServiceDto queryDto);

    public Task<ReviewServiceDto> GetByIdAsync(long id);

    public Task<ReviewServiceDto> AddAsync(AddReviewServiceDto addDto);

    public Task DeleteAsync(long id);

    public Task UpdateAsync(UpdateReviewServiceDto updateDto);
}