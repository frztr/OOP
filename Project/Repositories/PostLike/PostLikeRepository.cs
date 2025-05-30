
using AutoMapper;
using Microsoft.EntityFrameworkCore;
namespace Global;
public class PostLikeRepository(AppDbContext db) : IPostLikeRepository
{ 
    DbSet<PostLike> set = db.Set<PostLike>();
    public async Task<PostLikeRepositoryDto> AddAsync(AddPostLikeRepositoryDto addDto)
    {  
        var config = new MapperConfiguration(cfg => cfg.CreateMap<AddPostLikeRepositoryDto, PostLike>());
        var mapper = new Mapper(config);
        var entity = mapper.Map<AddPostLikeRepositoryDto, PostLike>(addDto);
        await set.AddAsync(entity);
        await db.SaveChangesAsync();
        var config2 = new MapperConfiguration(cfg => cfg.CreateMap<PostLike,PostLikeRepositoryDto>());
        var mapper2 = new Mapper(config2);
        var dto = mapper2.Map<PostLike,PostLikeRepositoryDto>(entity);
        return dto;
    }

    public async Task DeleteAsync(long id)
    {
        var entity = await set.FirstOrDefaultAsync(x => x.Id == id);
        if(entity == null) throw new EntityNotFoundException<PostLike>(new {id});
        set.Remove(entity);
        await db.SaveChangesAsync();
    }

    public async Task<PostLikeListRepositoryDto> GetAllAsync(PostLikeQueryRepositoryDto queryDto)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<PostLike,PostLikeRepositoryDto>());
        var mapper = new Mapper(config);
        return new PostLikeListRepositoryDto()
        {
            Items = mapper.Map<List<PostLikeRepositoryDto>>(
            await set
.Skip(queryDto.Offset).Take(queryDto.Count < 50 ? queryDto.Count : 50).ToListAsync()
            )
        };
    }

    public async Task<PostLikeRepositoryDto> GetByIdAsync(long id)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<PostLike,PostLikeRepositoryDto>());
        var mapper = new Mapper(config);
        var entity = await set.FirstOrDefaultAsync(x => x.Id == id);
        if(entity == null) throw new EntityNotFoundException<PostLike>(new {id});
        return mapper.Map<PostLike,PostLikeRepositoryDto>(entity);
    }

    public async Task UpdateAsync(UpdatePostLikeRepositoryDto updateDto)
    {
        var entity = await set.FirstOrDefaultAsync(x => x.Id == updateDto.Id);
        if(entity == null) throw new EntityNotFoundException<PostLike>(new {Id = updateDto.Id});
		if(updateDto.PostId.HasValue){
            entity.PostId = updateDto.PostId.Value;
        }

		if(updateDto.UserId.HasValue){
            entity.UserId = updateDto.UserId.Value;
        }


        await db.SaveChangesAsync();
    }
}