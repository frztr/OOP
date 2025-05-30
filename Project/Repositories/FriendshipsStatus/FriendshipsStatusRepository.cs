
using AutoMapper;
using Microsoft.EntityFrameworkCore;
namespace Global;
public class FriendshipsStatusRepository(AppDbContext db) : IFriendshipsStatusRepository
{ 
    DbSet<FriendshipsStatus> set = db.Set<FriendshipsStatus>();
    public async Task<FriendshipsStatusRepositoryDto> AddAsync(AddFriendshipsStatusRepositoryDto addDto)
    {  
        var config = new MapperConfiguration(cfg => cfg.CreateMap<AddFriendshipsStatusRepositoryDto, FriendshipsStatus>());
        var mapper = new Mapper(config);
        var entity = mapper.Map<AddFriendshipsStatusRepositoryDto, FriendshipsStatus>(addDto);
        await set.AddAsync(entity);
        await db.SaveChangesAsync();
        var config2 = new MapperConfiguration(cfg => cfg.CreateMap<FriendshipsStatus,FriendshipsStatusRepositoryDto>());
        var mapper2 = new Mapper(config2);
        var dto = mapper2.Map<FriendshipsStatus,FriendshipsStatusRepositoryDto>(entity);
        return dto;
    }

    public async Task DeleteAsync(short id)
    {
        var entity = await set.FirstOrDefaultAsync(x => x.Id == id);
        if(entity == null) throw new EntityNotFoundException<FriendshipsStatus>(new {id});
        set.Remove(entity);
        await db.SaveChangesAsync();
    }

    public async Task<FriendshipsStatusListRepositoryDto> GetAllAsync(FriendshipsStatusQueryRepositoryDto queryDto)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<FriendshipsStatus,FriendshipsStatusRepositoryDto>());
        var mapper = new Mapper(config);
        return new FriendshipsStatusListRepositoryDto()
        {
            Items = mapper.Map<List<FriendshipsStatusRepositoryDto>>(
            await set
.Skip(queryDto.Offset).Take(queryDto.Count < 50 ? queryDto.Count : 50).ToListAsync()
            )
        };
    }

    public async Task<FriendshipsStatusRepositoryDto> GetByIdAsync(short id)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<FriendshipsStatus,FriendshipsStatusRepositoryDto>());
        var mapper = new Mapper(config);
        var entity = await set.FirstOrDefaultAsync(x => x.Id == id);
        if(entity == null) throw new EntityNotFoundException<FriendshipsStatus>(new {id});
        return mapper.Map<FriendshipsStatus,FriendshipsStatusRepositoryDto>(entity);
    }

    public async Task UpdateAsync(UpdateFriendshipsStatusRepositoryDto updateDto)
    {
        var entity = await set.FirstOrDefaultAsync(x => x.Id == updateDto.Id);
        if(entity == null) throw new EntityNotFoundException<FriendshipsStatus>(new {Id = updateDto.Id});
		if(!String.IsNullOrEmpty(updateDto.Name)){
            entity.Name = updateDto.Name;
        }

        await db.SaveChangesAsync();
    }
}