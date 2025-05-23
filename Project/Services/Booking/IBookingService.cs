
namespace Global;
public interface IBookingService
{
    public Task<BookingListServiceDto> GetAllAsync(BookingQueryServiceDto queryDto);

    public Task<BookingServiceDto> GetByIdAsync(long id);

    public Task<BookingServiceDto> AddAsync(AddBookingServiceDto addDto);

    public Task DeleteAsync(long id);

    public Task UpdateAsync(UpdateBookingServiceDto updateDto);
}