
using AutoMapper;
namespace Global;
using Microsoft.Extensions.Logging;
public class BookingStatusService(IBookingStatusRepository repository,

ILogger<BookingStatusService> logger) : IBookingStatusService
{
    public async Task<BookingStatusServiceDto> AddAsync(AddBookingStatusServiceDto addServiceDto)
    {
        logger.Log(LogLevel.Debug,"Add()");
        var config = new MapperConfiguration(cfg => cfg.CreateMap<AddBookingStatusServiceDto, AddBookingStatusRepositoryDto>());
        var mapper = new Mapper(config);
        var addRepositoryDto = mapper.Map<AddBookingStatusServiceDto, AddBookingStatusRepositoryDto>(addServiceDto);
        await Task.WhenAll(
        );
        var entityRepositoryDto = await repository.AddAsync(addRepositoryDto);
        var config2 = new MapperConfiguration(cfg => cfg.CreateMap<BookingStatusRepositoryDto, BookingStatusServiceDto>());
        var mapper2 = new Mapper(config2);
        return mapper2.Map<BookingStatusRepositoryDto, BookingStatusServiceDto>(entityRepositoryDto);
    }

    public async Task DeleteAsync(short id)
    {
        logger.Log(LogLevel.Debug,"Delete()");
        await repository.DeleteAsync(id);
    }

    public async Task<BookingStatusListServiceDto> GetAllAsync(BookingStatusQueryServiceDto queryDto)
    {
        logger.Log(LogLevel.Debug,"GetAll()");
        var config = new MapperConfiguration(cfg => cfg.CreateMap<BookingStatusQueryServiceDto,BookingStatusQueryRepositoryDto>());
        var mapper = new Mapper(config);
        var dto = mapper.Map<BookingStatusQueryServiceDto,BookingStatusQueryRepositoryDto>(queryDto);    
        var config2 = new MapperConfiguration(cfg => cfg.CreateMap<BookingStatusRepositoryDto,BookingStatusServiceDto>());
        var mapper2 = new Mapper(config2);
        return new BookingStatusListServiceDto(){
            Items = (await repository.GetAllAsync(dto)).Items.Select(x=>mapper2.Map<BookingStatusServiceDto>(x))
        };
    }

    public async Task<BookingStatusServiceDto> GetByIdAsync(short id)
    {
        logger.Log(LogLevel.Debug,"GetById()");
        var config = new MapperConfiguration(cfg => cfg.CreateMap<BookingStatusRepositoryDto, BookingStatusServiceDto>());
        var mapper = new Mapper(config);
        return mapper.Map<BookingStatusRepositoryDto, BookingStatusServiceDto>(await repository.GetByIdAsync(id));
    }

    public async Task UpdateAsync(UpdateBookingStatusServiceDto updateDto)
    {
        logger.Log(LogLevel.Debug,"Update()");
        var config = new MapperConfiguration(cfg => cfg.CreateMap<UpdateBookingStatusServiceDto, UpdateBookingStatusRepositoryDto>());
        var mapper = new Mapper(config);
        var updateRepositoryDto = mapper.Map<UpdateBookingStatusServiceDto, UpdateBookingStatusRepositoryDto>(updateDto);
        await Task.WhenAll(
        );
        await repository.UpdateAsync(updateRepositoryDto);
    }
}