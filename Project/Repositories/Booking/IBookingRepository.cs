
namespace Global;
public interface IBookingRepository
{
    public Task<BookingListRepositoryDto> GetAllAsync(BookingQueryRepositoryDto queryDto);

    public Task<BookingRepositoryDto> GetByIdAsync(long id);

    public Task<BookingRepositoryDto> AddAsync(AddBookingRepositoryDto addDto);

    public Task DeleteAsync(long id);

    public Task UpdateAsync(UpdateBookingRepositoryDto updateDto);
}