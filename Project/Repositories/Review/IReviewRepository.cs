
namespace Global;
public interface IReviewRepository
{
    public Task<ReviewListRepositoryDto> GetAllAsync(ReviewQueryRepositoryDto queryDto);

    public Task<ReviewRepositoryDto> GetByIdAsync(long id);

    public Task<ReviewRepositoryDto> AddAsync(AddReviewRepositoryDto addDto);

    public Task DeleteAsync(long id);

    public Task UpdateAsync(UpdateReviewRepositoryDto updateDto);
}