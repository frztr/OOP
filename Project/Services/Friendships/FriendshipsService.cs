
using AutoMapper;
namespace Global;
using Microsoft.Extensions.Logging;
public class FriendshipsService(IFriendshipsRepository repository,
IUserRepository userRepository,
IFriendshipsStatusRepository friendshipsStatusRepository,
ILogger<FriendshipsService> logger) : IFriendshipsService
{
    public async Task<FriendshipsServiceDto> AddAsync(AddFriendshipsServiceDto addServiceDto)
    {
        logger.Log(LogLevel.Debug,"Add()");
        var config = new MapperConfiguration(cfg => cfg.CreateMap<AddFriendshipsServiceDto, AddFriendshipsRepositoryDto>());
        var mapper = new Mapper(config);
        var addRepositoryDto = mapper.Map<AddFriendshipsServiceDto, AddFriendshipsRepositoryDto>(addServiceDto);
        await Task.WhenAll(
        userRepository.GetByIdAsync(addRepositoryDto.User1Id),
		userRepository.GetByIdAsync(addRepositoryDto.User2Id),
		friendshipsStatusRepository.GetByIdAsync(addRepositoryDto.FriendshipsStatusId));
        var entityRepositoryDto = await repository.AddAsync(addRepositoryDto);
        var config2 = new MapperConfiguration(cfg => cfg.CreateMap<FriendshipsRepositoryDto, FriendshipsServiceDto>());
        var mapper2 = new Mapper(config2);
        return mapper2.Map<FriendshipsRepositoryDto, FriendshipsServiceDto>(entityRepositoryDto);
    }

    public async Task DeleteAsync(long id)
    {
        logger.Log(LogLevel.Debug,"Delete()");
        await repository.DeleteAsync(id);
    }

    public async Task<FriendshipsListServiceDto> GetAllAsync(FriendshipsQueryServiceDto queryDto)
    {
        logger.Log(LogLevel.Debug,"GetAll()");
        var config = new MapperConfiguration(cfg => cfg.CreateMap<FriendshipsQueryServiceDto,FriendshipsQueryRepositoryDto>());
        var mapper = new Mapper(config);
        var dto = mapper.Map<FriendshipsQueryServiceDto,FriendshipsQueryRepositoryDto>(queryDto);    
        var config2 = new MapperConfiguration(cfg => cfg.CreateMap<FriendshipsRepositoryDto,FriendshipsServiceDto>());
        var mapper2 = new Mapper(config2);
        return new FriendshipsListServiceDto(){
            Items = (await repository.GetAllAsync(dto)).Items.Select(x=>mapper2.Map<FriendshipsServiceDto>(x))
        };
    }

    public async Task<FriendshipsServiceDto> GetByIdAsync(long id)
    {
        logger.Log(LogLevel.Debug,"GetById()");
        var config = new MapperConfiguration(cfg => cfg.CreateMap<FriendshipsRepositoryDto, FriendshipsServiceDto>());
        var mapper = new Mapper(config);
        return mapper.Map<FriendshipsRepositoryDto, FriendshipsServiceDto>(await repository.GetByIdAsync(id));
    }

    public async Task UpdateAsync(UpdateFriendshipsServiceDto updateDto)
    {
        logger.Log(LogLevel.Debug,"Update()");
        var config = new MapperConfiguration(cfg => cfg.CreateMap<UpdateFriendshipsServiceDto, UpdateFriendshipsRepositoryDto>());
        var mapper = new Mapper(config);
        var updateRepositoryDto = mapper.Map<UpdateFriendshipsServiceDto, UpdateFriendshipsRepositoryDto>(updateDto);
        await Task.WhenAll(
        updateDto.User1Id.HasValue ? userRepository.GetByIdAsync(updateDto.User1Id.Value) : Task.CompletedTask,
		updateDto.User2Id.HasValue ? userRepository.GetByIdAsync(updateDto.User2Id.Value) : Task.CompletedTask,
		updateDto.FriendshipsStatusId.HasValue ? friendshipsStatusRepository.GetByIdAsync(updateDto.FriendshipsStatusId.Value) : Task.CompletedTask);
        await repository.UpdateAsync(updateRepositoryDto);
    }
}