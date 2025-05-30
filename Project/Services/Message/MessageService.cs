
using AutoMapper;
namespace Global;
using Microsoft.Extensions.Logging;
public class MessageService(IMessageRepository repository,
IUserRepository userRepository,
ILogger<MessageService> logger) : IMessageService
{
    public async Task<MessageServiceDto> AddAsync(AddMessageServiceDto addServiceDto)
    {
        logger.Log(LogLevel.Debug,"Add()");
        var config = new MapperConfiguration(cfg => cfg.CreateMap<AddMessageServiceDto, AddMessageRepositoryDto>());
        var mapper = new Mapper(config);
        var addRepositoryDto = mapper.Map<AddMessageServiceDto, AddMessageRepositoryDto>(addServiceDto);
        await Task.WhenAll(
        userRepository.GetByIdAsync(addRepositoryDto.SenderId),
		userRepository.GetByIdAsync(addRepositoryDto.ReceiverId),
		addRepositoryDto.ReplyTo.HasValue ? repository.GetByIdAsync(addRepositoryDto.ReplyTo.Value) : Task.CompletedTask);
        var entityRepositoryDto = await repository.AddAsync(addRepositoryDto);
        var config2 = new MapperConfiguration(cfg => cfg.CreateMap<MessageRepositoryDto, MessageServiceDto>());
        var mapper2 = new Mapper(config2);
        return mapper2.Map<MessageRepositoryDto, MessageServiceDto>(entityRepositoryDto);
    }

    public async Task DeleteAsync(long id)
    {
        logger.Log(LogLevel.Debug,"Delete()");
        await repository.DeleteAsync(id);
    }

    public async Task<MessageListServiceDto> GetAllAsync(MessageQueryServiceDto queryDto)
    {
        logger.Log(LogLevel.Debug,"GetAll()");
        var config = new MapperConfiguration(cfg => cfg.CreateMap<MessageQueryServiceDto,MessageQueryRepositoryDto>());
        var mapper = new Mapper(config);
        var dto = mapper.Map<MessageQueryServiceDto,MessageQueryRepositoryDto>(queryDto);    
        var config2 = new MapperConfiguration(cfg => cfg.CreateMap<MessageRepositoryDto,MessageServiceDto>());
        var mapper2 = new Mapper(config2);
        return new MessageListServiceDto(){
            Items = (await repository.GetAllAsync(dto)).Items.Select(x=>mapper2.Map<MessageServiceDto>(x))
        };
    }

    public async Task<MessageServiceDto> GetByIdAsync(long id)
    {
        logger.Log(LogLevel.Debug,"GetById()");
        var config = new MapperConfiguration(cfg => cfg.CreateMap<MessageRepositoryDto, MessageServiceDto>());
        var mapper = new Mapper(config);
        return mapper.Map<MessageRepositoryDto, MessageServiceDto>(await repository.GetByIdAsync(id));
    }

    public async Task UpdateAsync(UpdateMessageServiceDto updateDto)
    {
        logger.Log(LogLevel.Debug,"Update()");
        var config = new MapperConfiguration(cfg => cfg.CreateMap<UpdateMessageServiceDto, UpdateMessageRepositoryDto>());
        var mapper = new Mapper(config);
        var updateRepositoryDto = mapper.Map<UpdateMessageServiceDto, UpdateMessageRepositoryDto>(updateDto);
        await Task.WhenAll(
        updateDto.SenderId.HasValue ? userRepository.GetByIdAsync(updateDto.SenderId.Value) : Task.CompletedTask,
		updateDto.ReceiverId.HasValue ? userRepository.GetByIdAsync(updateDto.ReceiverId.Value) : Task.CompletedTask,
		updateDto.ReplyTo.HasValue ? repository.GetByIdAsync(updateDto.ReplyTo.Value) : Task.CompletedTask);
        await repository.UpdateAsync(updateRepositoryDto);
    }
}