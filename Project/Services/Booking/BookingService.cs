
using AutoMapper;
namespace Global;
using Microsoft.Extensions.Logging;
public class BookingService(IBookingRepository repository,
IUserRepository userRepository,
IEventRepository eventRepository,
IBookingStatusRepository bookingStatusRepository,
ILogger<BookingService> logger) : IBookingService
{
    public async Task<BookingServiceDto> AddAsync(AddBookingServiceDto addServiceDto)
    {
        logger.Log(LogLevel.Debug,"Add()");
        var config = new MapperConfiguration(cfg => cfg.CreateMap<AddBookingServiceDto, AddBookingRepositoryDto>());
        var mapper = new Mapper(config);
        var addRepositoryDto = mapper.Map<AddBookingServiceDto, AddBookingRepositoryDto>(addServiceDto);
        await Task.WhenAll(
        userRepository.GetByIdAsync(addRepositoryDto.UserId),
		eventRepository.GetByIdAsync(addRepositoryDto.EventId),
		addRepositoryDto.BookingStatusId.HasValue ? bookingStatusRepository.GetByIdAsync(addRepositoryDto.BookingStatusId.Value) : Task.CompletedTask);
        var entityRepositoryDto = await repository.AddAsync(addRepositoryDto);
        var config2 = new MapperConfiguration(cfg => cfg.CreateMap<BookingRepositoryDto, BookingServiceDto>());
        var mapper2 = new Mapper(config2);
        return mapper2.Map<BookingRepositoryDto, BookingServiceDto>(entityRepositoryDto);
    }

    public async Task DeleteAsync(long id)
    {
        logger.Log(LogLevel.Debug,"Delete()");
        await repository.DeleteAsync(id);
    }

    public async Task<BookingListServiceDto> GetAllAsync(BookingQueryServiceDto queryDto)
    {
        logger.Log(LogLevel.Debug,"GetAll()");
        var config = new MapperConfiguration(cfg => cfg.CreateMap<BookingQueryServiceDto,BookingQueryRepositoryDto>());
        var mapper = new Mapper(config);
        var dto = mapper.Map<BookingQueryServiceDto,BookingQueryRepositoryDto>(queryDto);    
        var config2 = new MapperConfiguration(cfg => cfg.CreateMap<BookingRepositoryDto,BookingServiceDto>());
        var mapper2 = new Mapper(config2);
        return new BookingListServiceDto(){
            Items = (await repository.GetAllAsync(dto)).Items.Select(x=>mapper2.Map<BookingServiceDto>(x))
        };
    }

    public async Task<BookingServiceDto> GetByIdAsync(long id)
    {
        logger.Log(LogLevel.Debug,"GetById()");
        var config = new MapperConfiguration(cfg => cfg.CreateMap<BookingRepositoryDto, BookingServiceDto>());
        var mapper = new Mapper(config);
        return mapper.Map<BookingRepositoryDto, BookingServiceDto>(await repository.GetByIdAsync(id));
    }

    public async Task UpdateAsync(UpdateBookingServiceDto updateDto)
    {
        logger.Log(LogLevel.Debug,"Update()");
        var config = new MapperConfiguration(cfg => cfg.CreateMap<UpdateBookingServiceDto, UpdateBookingRepositoryDto>());
        var mapper = new Mapper(config);
        var updateRepositoryDto = mapper.Map<UpdateBookingServiceDto, UpdateBookingRepositoryDto>(updateDto);
        await Task.WhenAll(
        updateDto.UserId.HasValue ? userRepository.GetByIdAsync(updateDto.UserId.Value) : Task.CompletedTask,
		updateDto.EventId.HasValue ? eventRepository.GetByIdAsync(updateDto.EventId.Value) : Task.CompletedTask,
		updateDto.BookingStatusId.HasValue ? bookingStatusRepository.GetByIdAsync(updateDto.BookingStatusId.Value) : Task.CompletedTask);
        await repository.UpdateAsync(updateRepositoryDto);
    }
}