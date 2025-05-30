
using AutoMapper;
using Microsoft.EntityFrameworkCore;
namespace Global;
public class FriendshipsRepository(AppDbContext db) : IFriendshipsRepository
{ 
    DbSet<Friendships> set = db.Set<Friendships>();
    public async Task<FriendshipsRepositoryDto> AddAsync(AddFriendshipsRepositoryDto addDto)
    {  
        var config = new MapperConfiguration(cfg => cfg.CreateMap<AddFriendshipsRepositoryDto, Friendships>());
        var mapper = new Mapper(config);
        var entity = mapper.Map<AddFriendshipsRepositoryDto, Friendships>(addDto);
        await set.AddAsync(entity);
        await db.SaveChangesAsync();
        var config2 = new MapperConfiguration(cfg => cfg.CreateMap<Friendships,FriendshipsRepositoryDto>());
        var mapper2 = new Mapper(config2);
        var dto = mapper2.Map<Friendships,FriendshipsRepositoryDto>(entity);
        return dto;
    }

    public async Task DeleteAsync(long id)
    {
        var entity = await set.FirstOrDefaultAsync(x => x.Id == id);
        if(entity == null) throw new EntityNotFoundException<Friendships>(new {id});
        set.Remove(entity);
        await db.SaveChangesAsync();
    }

    public async Task<FriendshipsListRepositoryDto> GetAllAsync(FriendshipsQueryRepositoryDto queryDto)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<Friendships,FriendshipsRepositoryDto>());
        var mapper = new Mapper(config);
        return new FriendshipsListRepositoryDto()
        {
            Items = mapper.Map<List<FriendshipsRepositoryDto>>(
            await set
.Skip(queryDto.Offset).Take(queryDto.Count < 50 ? queryDto.Count : 50).ToListAsync()
            )
        };
    }

    public async Task<FriendshipsRepositoryDto> GetByIdAsync(long id)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<Friendships,FriendshipsRepositoryDto>());
        var mapper = new Mapper(config);
        var entity = await set.FirstOrDefaultAsync(x => x.Id == id);
        if(entity == null) throw new EntityNotFoundException<Friendships>(new {id});
        return mapper.Map<Friendships,FriendshipsRepositoryDto>(entity);
    }

    public async Task UpdateAsync(UpdateFriendshipsRepositoryDto updateDto)
    {
        var entity = await set.FirstOrDefaultAsync(x => x.Id == updateDto.Id);
        if(entity == null) throw new EntityNotFoundException<Friendships>(new {Id = updateDto.Id});
		if(updateDto.User1Id.HasValue){
            entity.User1Id = updateDto.User1Id.Value;
        }

		if(updateDto.User2Id.HasValue){
            entity.User2Id = updateDto.User2Id.Value;
        }

		if(updateDto.FriendshipsStatusId.HasValue){
            entity.FriendshipsStatusId = updateDto.FriendshipsStatusId.Value;
        }



        await db.SaveChangesAsync();
    }
}