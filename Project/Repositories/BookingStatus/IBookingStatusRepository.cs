
namespace Global;
public interface IBookingStatusRepository
{
    public Task<BookingStatusListRepositoryDto> GetAllAsync(BookingStatusQueryRepositoryDto queryDto);

    public Task<BookingStatusRepositoryDto> GetByIdAsync(short id);

    public Task<BookingStatusRepositoryDto> AddAsync(AddBookingStatusRepositoryDto addDto);

    public Task DeleteAsync(short id);

    public Task UpdateAsync(UpdateBookingStatusRepositoryDto updateDto);
}