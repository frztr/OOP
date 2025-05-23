
using AutoMapper;
namespace Global;
using Microsoft.Extensions.Logging;
public class ReviewService(IReviewRepository repository,
IUserRepository userRepository,
IEventRepository eventRepository,
ILogger<ReviewService> logger) : IReviewService
{
    public async Task<ReviewServiceDto> AddAsync(AddReviewServiceDto addServiceDto)
    {
        logger.Log(LogLevel.Debug,"Add()");
        var config = new MapperConfiguration(cfg => cfg.CreateMap<AddReviewServiceDto, AddReviewRepositoryDto>());
        var mapper = new Mapper(config);
        var addRepositoryDto = mapper.Map<AddReviewServiceDto, AddReviewRepositoryDto>(addServiceDto);
        await Task.WhenAll(
        userRepository.GetByIdAsync(addRepositoryDto.UserId),
		eventRepository.GetByIdAsync(addRepositoryDto.EventId));
        var entityRepositoryDto = await repository.AddAsync(addRepositoryDto);
        var config2 = new MapperConfiguration(cfg => cfg.CreateMap<ReviewRepositoryDto, ReviewServiceDto>());
        var mapper2 = new Mapper(config2);
        return mapper2.Map<ReviewRepositoryDto, ReviewServiceDto>(entityRepositoryDto);
    }

    public async Task DeleteAsync(long id)
    {
        logger.Log(LogLevel.Debug,"Delete()");
        await repository.DeleteAsync(id);
    }

    public async Task<ReviewListServiceDto> GetAllAsync(ReviewQueryServiceDto queryDto)
    {
        logger.Log(LogLevel.Debug,"GetAll()");
        var config = new MapperConfiguration(cfg => cfg.CreateMap<ReviewQueryServiceDto,ReviewQueryRepositoryDto>());
        var mapper = new Mapper(config);
        var dto = mapper.Map<ReviewQueryServiceDto,ReviewQueryRepositoryDto>(queryDto);    
        var config2 = new MapperConfiguration(cfg => cfg.CreateMap<ReviewRepositoryDto,ReviewServiceDto>());
        var mapper2 = new Mapper(config2);
        return new ReviewListServiceDto(){
            Items = (await repository.GetAllAsync(dto)).Items.Select(x=>mapper2.Map<ReviewServiceDto>(x))
        };
    }

    public async Task<ReviewServiceDto> GetByIdAsync(long id)
    {
        logger.Log(LogLevel.Debug,"GetById()");
        var config = new MapperConfiguration(cfg => cfg.CreateMap<ReviewRepositoryDto, ReviewServiceDto>());
        var mapper = new Mapper(config);
        return mapper.Map<ReviewRepositoryDto, ReviewServiceDto>(await repository.GetByIdAsync(id));
    }

    public async Task UpdateAsync(UpdateReviewServiceDto updateDto)
    {
        logger.Log(LogLevel.Debug,"Update()");
        var config = new MapperConfiguration(cfg => cfg.CreateMap<UpdateReviewServiceDto, UpdateReviewRepositoryDto>());
        var mapper = new Mapper(config);
        var updateRepositoryDto = mapper.Map<UpdateReviewServiceDto, UpdateReviewRepositoryDto>(updateDto);
        await Task.WhenAll(
        updateDto.UserId.HasValue ? userRepository.GetByIdAsync(updateDto.UserId.Value) : Task.CompletedTask,
		updateDto.EventId.HasValue ? eventRepository.GetByIdAsync(updateDto.EventId.Value) : Task.CompletedTask);
        await repository.UpdateAsync(updateRepositoryDto);
    }
}