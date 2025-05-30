
using AutoMapper;
namespace Global;
using Microsoft.Extensions.Logging;
public class PostService(IPostRepository repository,
IUserRepository userRepository,
ILogger<PostService> logger) : IPostService
{
    public async Task<PostServiceDto> AddAsync(AddPostServiceDto addServiceDto)
    {
        logger.Log(LogLevel.Debug,"Add()");
        var config = new MapperConfiguration(cfg => cfg.CreateMap<AddPostServiceDto, AddPostRepositoryDto>());
        var mapper = new Mapper(config);
        var addRepositoryDto = mapper.Map<AddPostServiceDto, AddPostRepositoryDto>(addServiceDto);
        await Task.WhenAll(
        userRepository.GetByIdAsync(addRepositoryDto.UserId));
        var entityRepositoryDto = await repository.AddAsync(addRepositoryDto);
        var config2 = new MapperConfiguration(cfg => cfg.CreateMap<PostRepositoryDto, PostServiceDto>());
        var mapper2 = new Mapper(config2);
        return mapper2.Map<PostRepositoryDto, PostServiceDto>(entityRepositoryDto);
    }

    public async Task DeleteAsync(long id)
    {
        logger.Log(LogLevel.Debug,"Delete()");
        await repository.DeleteAsync(id);
    }

    public async Task<PostListServiceDto> GetAllAsync(PostQueryServiceDto queryDto)
    {
        logger.Log(LogLevel.Debug,"GetAll()");
        var config = new MapperConfiguration(cfg => cfg.CreateMap<PostQueryServiceDto,PostQueryRepositoryDto>());
        var mapper = new Mapper(config);
        var dto = mapper.Map<PostQueryServiceDto,PostQueryRepositoryDto>(queryDto);    
        var config2 = new MapperConfiguration(cfg => cfg.CreateMap<PostRepositoryDto,PostServiceDto>());
        var mapper2 = new Mapper(config2);
        return new PostListServiceDto(){
            Items = (await repository.GetAllAsync(dto)).Items.Select(x=>mapper2.Map<PostServiceDto>(x))
        };
    }

    public async Task<PostServiceDto> GetByIdAsync(long id)
    {
        logger.Log(LogLevel.Debug,"GetById()");
        var config = new MapperConfiguration(cfg => cfg.CreateMap<PostRepositoryDto, PostServiceDto>());
        var mapper = new Mapper(config);
        return mapper.Map<PostRepositoryDto, PostServiceDto>(await repository.GetByIdAsync(id));
    }

    public async Task UpdateAsync(UpdatePostServiceDto updateDto)
    {
        logger.Log(LogLevel.Debug,"Update()");
        var config = new MapperConfiguration(cfg => cfg.CreateMap<UpdatePostServiceDto, UpdatePostRepositoryDto>());
        var mapper = new Mapper(config);
        var updateRepositoryDto = mapper.Map<UpdatePostServiceDto, UpdatePostRepositoryDto>(updateDto);
        await Task.WhenAll(
        updateDto.UserId.HasValue ? userRepository.GetByIdAsync(updateDto.UserId.Value) : Task.CompletedTask);
        await repository.UpdateAsync(updateRepositoryDto);
    }
}