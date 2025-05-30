
using AutoMapper;
using Microsoft.EntityFrameworkCore;
namespace Global;
public class PostRepository(AppDbContext db) : IPostRepository
{ 
    DbSet<Post> set = db.Set<Post>();
    public async Task<PostRepositoryDto> AddAsync(AddPostRepositoryDto addDto)
    {  
        var config = new MapperConfiguration(cfg => cfg.CreateMap<AddPostRepositoryDto, Post>());
        var mapper = new Mapper(config);
        var entity = mapper.Map<AddPostRepositoryDto, Post>(addDto);
        await set.AddAsync(entity);
        await db.SaveChangesAsync();
        var config2 = new MapperConfiguration(cfg => cfg.CreateMap<Post,PostRepositoryDto>());
        var mapper2 = new Mapper(config2);
        var dto = mapper2.Map<Post,PostRepositoryDto>(entity);
        return dto;
    }

    public async Task DeleteAsync(long id)
    {
        var entity = await set.FirstOrDefaultAsync(x => x.Id == id);
        if(entity == null) throw new EntityNotFoundException<Post>(new {id});
        set.Remove(entity);
        await db.SaveChangesAsync();
    }

    public async Task<PostListRepositoryDto> GetAllAsync(PostQueryRepositoryDto queryDto)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<Post,PostRepositoryDto>());
        var mapper = new Mapper(config);
        return new PostListRepositoryDto()
        {
            Items = mapper.Map<List<PostRepositoryDto>>(
            await set
.Skip(queryDto.Offset).Take(queryDto.Count < 50 ? queryDto.Count : 50).ToListAsync()
            )
        };
    }

    public async Task<PostRepositoryDto> GetByIdAsync(long id)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<Post,PostRepositoryDto>());
        var mapper = new Mapper(config);
        var entity = await set.FirstOrDefaultAsync(x => x.Id == id);
        if(entity == null) throw new EntityNotFoundException<Post>(new {id});
        return mapper.Map<Post,PostRepositoryDto>(entity);
    }

    public async Task UpdateAsync(UpdatePostRepositoryDto updateDto)
    {
        var entity = await set.FirstOrDefaultAsync(x => x.Id == updateDto.Id);
        if(entity == null) throw new EntityNotFoundException<Post>(new {Id = updateDto.Id});
		if(updateDto.UserId.HasValue){
            entity.UserId = updateDto.UserId.Value;
        }

		if(!String.IsNullOrEmpty(updateDto.Content)){
            entity.Content = updateDto.Content;
        }




        await db.SaveChangesAsync();
    }
}