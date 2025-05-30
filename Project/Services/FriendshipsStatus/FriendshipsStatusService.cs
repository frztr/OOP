
using AutoMapper;
namespace Global;
using Microsoft.Extensions.Logging;
public class FriendshipsStatusService(IFriendshipsStatusRepository repository,

ILogger<FriendshipsStatusService> logger) : IFriendshipsStatusService
{
    public async Task<FriendshipsStatusServiceDto> AddAsync(AddFriendshipsStatusServiceDto addServiceDto)
    {
        logger.Log(LogLevel.Debug,"Add()");
        var config = new MapperConfiguration(cfg => cfg.CreateMap<AddFriendshipsStatusServiceDto, AddFriendshipsStatusRepositoryDto>());
        var mapper = new Mapper(config);
        var addRepositoryDto = mapper.Map<AddFriendshipsStatusServiceDto, AddFriendshipsStatusRepositoryDto>(addServiceDto);
        await Task.WhenAll(
        );
        var entityRepositoryDto = await repository.AddAsync(addRepositoryDto);
        var config2 = new MapperConfiguration(cfg => cfg.CreateMap<FriendshipsStatusRepositoryDto, FriendshipsStatusServiceDto>());
        var mapper2 = new Mapper(config2);
        return mapper2.Map<FriendshipsStatusRepositoryDto, FriendshipsStatusServiceDto>(entityRepositoryDto);
    }

    public async Task DeleteAsync(short id)
    {
        logger.Log(LogLevel.Debug,"Delete()");
        await repository.DeleteAsync(id);
    }

    public async Task<FriendshipsStatusListServiceDto> GetAllAsync(FriendshipsStatusQueryServiceDto queryDto)
    {
        logger.Log(LogLevel.Debug,"GetAll()");
        var config = new MapperConfiguration(cfg => cfg.CreateMap<FriendshipsStatusQueryServiceDto,FriendshipsStatusQueryRepositoryDto>());
        var mapper = new Mapper(config);
        var dto = mapper.Map<FriendshipsStatusQueryServiceDto,FriendshipsStatusQueryRepositoryDto>(queryDto);    
        var config2 = new MapperConfiguration(cfg => cfg.CreateMap<FriendshipsStatusRepositoryDto,FriendshipsStatusServiceDto>());
        var mapper2 = new Mapper(config2);
        return new FriendshipsStatusListServiceDto(){
            Items = (await repository.GetAllAsync(dto)).Items.Select(x=>mapper2.Map<FriendshipsStatusServiceDto>(x))
        };
    }

    public async Task<FriendshipsStatusServiceDto> GetByIdAsync(short id)
    {
        logger.Log(LogLevel.Debug,"GetById()");
        var config = new MapperConfiguration(cfg => cfg.CreateMap<FriendshipsStatusRepositoryDto, FriendshipsStatusServiceDto>());
        var mapper = new Mapper(config);
        return mapper.Map<FriendshipsStatusRepositoryDto, FriendshipsStatusServiceDto>(await repository.GetByIdAsync(id));
    }

    public async Task UpdateAsync(UpdateFriendshipsStatusServiceDto updateDto)
    {
        logger.Log(LogLevel.Debug,"Update()");
        var config = new MapperConfiguration(cfg => cfg.CreateMap<UpdateFriendshipsStatusServiceDto, UpdateFriendshipsStatusRepositoryDto>());
        var mapper = new Mapper(config);
        var updateRepositoryDto = mapper.Map<UpdateFriendshipsStatusServiceDto, UpdateFriendshipsStatusRepositoryDto>(updateDto);
        await Task.WhenAll(
        );
        await repository.UpdateAsync(updateRepositoryDto);
    }
}