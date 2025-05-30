
using AutoMapper;
namespace Global;
using Microsoft.Extensions.Logging;
public class CommentLikeService(ICommentLikeRepository repository,
ICommentRepository commentRepository,
IUserRepository userRepository,
ILogger<CommentLikeService> logger) : ICommentLikeService
{
    public async Task<CommentLikeServiceDto> AddAsync(AddCommentLikeServiceDto addServiceDto)
    {
        logger.Log(LogLevel.Debug,"Add()");
        var config = new MapperConfiguration(cfg => cfg.CreateMap<AddCommentLikeServiceDto, AddCommentLikeRepositoryDto>());
        var mapper = new Mapper(config);
        var addRepositoryDto = mapper.Map<AddCommentLikeServiceDto, AddCommentLikeRepositoryDto>(addServiceDto);
        await Task.WhenAll(
        commentRepository.GetByIdAsync(addRepositoryDto.CommentId),
		userRepository.GetByIdAsync(addRepositoryDto.UserId));
        var entityRepositoryDto = await repository.AddAsync(addRepositoryDto);
        var config2 = new MapperConfiguration(cfg => cfg.CreateMap<CommentLikeRepositoryDto, CommentLikeServiceDto>());
        var mapper2 = new Mapper(config2);
        return mapper2.Map<CommentLikeRepositoryDto, CommentLikeServiceDto>(entityRepositoryDto);
    }

    public async Task DeleteAsync(long id)
    {
        logger.Log(LogLevel.Debug,"Delete()");
        await repository.DeleteAsync(id);
    }

    public async Task<CommentLikeListServiceDto> GetAllAsync(CommentLikeQueryServiceDto queryDto)
    {
        logger.Log(LogLevel.Debug,"GetAll()");
        var config = new MapperConfiguration(cfg => cfg.CreateMap<CommentLikeQueryServiceDto,CommentLikeQueryRepositoryDto>());
        var mapper = new Mapper(config);
        var dto = mapper.Map<CommentLikeQueryServiceDto,CommentLikeQueryRepositoryDto>(queryDto);    
        var config2 = new MapperConfiguration(cfg => cfg.CreateMap<CommentLikeRepositoryDto,CommentLikeServiceDto>());
        var mapper2 = new Mapper(config2);
        return new CommentLikeListServiceDto(){
            Items = (await repository.GetAllAsync(dto)).Items.Select(x=>mapper2.Map<CommentLikeServiceDto>(x))
        };
    }

    public async Task<CommentLikeServiceDto> GetByIdAsync(long id)
    {
        logger.Log(LogLevel.Debug,"GetById()");
        var config = new MapperConfiguration(cfg => cfg.CreateMap<CommentLikeRepositoryDto, CommentLikeServiceDto>());
        var mapper = new Mapper(config);
        return mapper.Map<CommentLikeRepositoryDto, CommentLikeServiceDto>(await repository.GetByIdAsync(id));
    }

    public async Task UpdateAsync(UpdateCommentLikeServiceDto updateDto)
    {
        logger.Log(LogLevel.Debug,"Update()");
        var config = new MapperConfiguration(cfg => cfg.CreateMap<UpdateCommentLikeServiceDto, UpdateCommentLikeRepositoryDto>());
        var mapper = new Mapper(config);
        var updateRepositoryDto = mapper.Map<UpdateCommentLikeServiceDto, UpdateCommentLikeRepositoryDto>(updateDto);
        await Task.WhenAll(
        updateDto.CommentId.HasValue ? commentRepository.GetByIdAsync(updateDto.CommentId.Value) : Task.CompletedTask,
		updateDto.UserId.HasValue ? userRepository.GetByIdAsync(updateDto.UserId.Value) : Task.CompletedTask);
        await repository.UpdateAsync(updateRepositoryDto);
    }
}