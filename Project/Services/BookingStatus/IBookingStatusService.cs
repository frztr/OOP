
namespace Global;
public interface IBookingStatusService
{
    public Task<BookingStatusListServiceDto> GetAllAsync(BookingStatusQueryServiceDto queryDto);

    public Task<BookingStatusServiceDto> GetByIdAsync(short id);

    public Task<BookingStatusServiceDto> AddAsync(AddBookingStatusServiceDto addDto);

    public Task DeleteAsync(short id);

    public Task UpdateAsync(UpdateBookingStatusServiceDto updateDto);
}