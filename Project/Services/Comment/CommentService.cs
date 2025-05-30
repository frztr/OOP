
using AutoMapper;
namespace Global;
using Microsoft.Extensions.Logging;
public class CommentService(ICommentRepository repository,
IPostRepository postRepository,
IUserRepository userRepository,
ILogger<CommentService> logger) : ICommentService
{
    public async Task<CommentServiceDto> AddAsync(AddCommentServiceDto addServiceDto)
    {
        logger.Log(LogLevel.Debug,"Add()");
        var config = new MapperConfiguration(cfg => cfg.CreateMap<AddCommentServiceDto, AddCommentRepositoryDto>());
        var mapper = new Mapper(config);
        var addRepositoryDto = mapper.Map<AddCommentServiceDto, AddCommentRepositoryDto>(addServiceDto);
        await Task.WhenAll(
        postRepository.GetByIdAsync(addRepositoryDto.PostId),
		userRepository.GetByIdAsync(addRepositoryDto.UserId),
		addRepositoryDto.ParentCommentId.HasValue ? repository.GetByIdAsync(addRepositoryDto.ParentCommentId.Value) : Task.CompletedTask);
        var entityRepositoryDto = await repository.AddAsync(addRepositoryDto);
        var config2 = new MapperConfiguration(cfg => cfg.CreateMap<CommentRepositoryDto, CommentServiceDto>());
        var mapper2 = new Mapper(config2);
        return mapper2.Map<CommentRepositoryDto, CommentServiceDto>(entityRepositoryDto);
    }

    public async Task DeleteAsync(long id)
    {
        logger.Log(LogLevel.Debug,"Delete()");
        await repository.DeleteAsync(id);
    }

    public async Task<CommentListServiceDto> GetAllAsync(CommentQueryServiceDto queryDto)
    {
        logger.Log(LogLevel.Debug,"GetAll()");
        var config = new MapperConfiguration(cfg => cfg.CreateMap<CommentQueryServiceDto,CommentQueryRepositoryDto>());
        var mapper = new Mapper(config);
        var dto = mapper.Map<CommentQueryServiceDto,CommentQueryRepositoryDto>(queryDto);    
        var config2 = new MapperConfiguration(cfg => cfg.CreateMap<CommentRepositoryDto,CommentServiceDto>());
        var mapper2 = new Mapper(config2);
        return new CommentListServiceDto(){
            Items = (await repository.GetAllAsync(dto)).Items.Select(x=>mapper2.Map<CommentServiceDto>(x))
        };
    }

    public async Task<CommentServiceDto> GetByIdAsync(long id)
    {
        logger.Log(LogLevel.Debug,"GetById()");
        var config = new MapperConfiguration(cfg => cfg.CreateMap<CommentRepositoryDto, CommentServiceDto>());
        var mapper = new Mapper(config);
        return mapper.Map<CommentRepositoryDto, CommentServiceDto>(await repository.GetByIdAsync(id));
    }

    public async Task UpdateAsync(UpdateCommentServiceDto updateDto)
    {
        logger.Log(LogLevel.Debug,"Update()");
        var config = new MapperConfiguration(cfg => cfg.CreateMap<UpdateCommentServiceDto, UpdateCommentRepositoryDto>());
        var mapper = new Mapper(config);
        var updateRepositoryDto = mapper.Map<UpdateCommentServiceDto, UpdateCommentRepositoryDto>(updateDto);
        await Task.WhenAll(
        updateDto.PostId.HasValue ? postRepository.GetByIdAsync(updateDto.PostId.Value) : Task.CompletedTask,
		updateDto.UserId.HasValue ? userRepository.GetByIdAsync(updateDto.UserId.Value) : Task.CompletedTask,
		updateDto.ParentCommentId.HasValue ? repository.GetByIdAsync(updateDto.ParentCommentId.Value) : Task.CompletedTask);
        await repository.UpdateAsync(updateRepositoryDto);
    }
}