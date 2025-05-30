
using AutoMapper;
namespace Global;
using Microsoft.Extensions.Logging;
public class PostLikeService(IPostLikeRepository repository,
IPostRepository postRepository,
IUserRepository userRepository,
ILogger<PostLikeService> logger) : IPostLikeService
{
    public async Task<PostLikeServiceDto> AddAsync(AddPostLikeServiceDto addServiceDto)
    {
        logger.Log(LogLevel.Debug,"Add()");
        var config = new MapperConfiguration(cfg => cfg.CreateMap<AddPostLikeServiceDto, AddPostLikeRepositoryDto>());
        var mapper = new Mapper(config);
        var addRepositoryDto = mapper.Map<AddPostLikeServiceDto, AddPostLikeRepositoryDto>(addServiceDto);
        await Task.WhenAll(
        postRepository.GetByIdAsync(addRepositoryDto.PostId),
		userRepository.GetByIdAsync(addRepositoryDto.UserId));
        var entityRepositoryDto = await repository.AddAsync(addRepositoryDto);
        var config2 = new MapperConfiguration(cfg => cfg.CreateMap<PostLikeRepositoryDto, PostLikeServiceDto>());
        var mapper2 = new Mapper(config2);
        return mapper2.Map<PostLikeRepositoryDto, PostLikeServiceDto>(entityRepositoryDto);
    }

    public async Task DeleteAsync(long id)
    {
        logger.Log(LogLevel.Debug,"Delete()");
        await repository.DeleteAsync(id);
    }

    public async Task<PostLikeListServiceDto> GetAllAsync(PostLikeQueryServiceDto queryDto)
    {
        logger.Log(LogLevel.Debug,"GetAll()");
        var config = new MapperConfiguration(cfg => cfg.CreateMap<PostLikeQueryServiceDto,PostLikeQueryRepositoryDto>());
        var mapper = new Mapper(config);
        var dto = mapper.Map<PostLikeQueryServiceDto,PostLikeQueryRepositoryDto>(queryDto);    
        var config2 = new MapperConfiguration(cfg => cfg.CreateMap<PostLikeRepositoryDto,PostLikeServiceDto>());
        var mapper2 = new Mapper(config2);
        return new PostLikeListServiceDto(){
            Items = (await repository.GetAllAsync(dto)).Items.Select(x=>mapper2.Map<PostLikeServiceDto>(x))
        };
    }

    public async Task<PostLikeServiceDto> GetByIdAsync(long id)
    {
        logger.Log(LogLevel.Debug,"GetById()");
        var config = new MapperConfiguration(cfg => cfg.CreateMap<PostLikeRepositoryDto, PostLikeServiceDto>());
        var mapper = new Mapper(config);
        return mapper.Map<PostLikeRepositoryDto, PostLikeServiceDto>(await repository.GetByIdAsync(id));
    }

    public async Task UpdateAsync(UpdatePostLikeServiceDto updateDto)
    {
        logger.Log(LogLevel.Debug,"Update()");
        var config = new MapperConfiguration(cfg => cfg.CreateMap<UpdatePostLikeServiceDto, UpdatePostLikeRepositoryDto>());
        var mapper = new Mapper(config);
        var updateRepositoryDto = mapper.Map<UpdatePostLikeServiceDto, UpdatePostLikeRepositoryDto>(updateDto);
        await Task.WhenAll(
        updateDto.PostId.HasValue ? postRepository.GetByIdAsync(updateDto.PostId.Value) : Task.CompletedTask,
		updateDto.UserId.HasValue ? userRepository.GetByIdAsync(updateDto.UserId.Value) : Task.CompletedTask);
        await repository.UpdateAsync(updateRepositoryDto);
    }
}