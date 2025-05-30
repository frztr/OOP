
using AutoMapper;
using Microsoft.EntityFrameworkCore;
namespace Global;
public class CommentLikeRepository(AppDbContext db) : ICommentLikeRepository
{ 
    DbSet<CommentLike> set = db.Set<CommentLike>();
    public async Task<CommentLikeRepositoryDto> AddAsync(AddCommentLikeRepositoryDto addDto)
    {  
        var config = new MapperConfiguration(cfg => cfg.CreateMap<AddCommentLikeRepositoryDto, CommentLike>());
        var mapper = new Mapper(config);
        var entity = mapper.Map<AddCommentLikeRepositoryDto, CommentLike>(addDto);
        await set.AddAsync(entity);
        await db.SaveChangesAsync();
        var config2 = new MapperConfiguration(cfg => cfg.CreateMap<CommentLike,CommentLikeRepositoryDto>());
        var mapper2 = new Mapper(config2);
        var dto = mapper2.Map<CommentLike,CommentLikeRepositoryDto>(entity);
        return dto;
    }

    public async Task DeleteAsync(long id)
    {
        var entity = await set.FirstOrDefaultAsync(x => x.Id == id);
        if(entity == null) throw new EntityNotFoundException<CommentLike>(new {id});
        set.Remove(entity);
        await db.SaveChangesAsync();
    }

    public async Task<CommentLikeListRepositoryDto> GetAllAsync(CommentLikeQueryRepositoryDto queryDto)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<CommentLike,CommentLikeRepositoryDto>());
        var mapper = new Mapper(config);
        return new CommentLikeListRepositoryDto()
        {
            Items = mapper.Map<List<CommentLikeRepositoryDto>>(
            await set
.Skip(queryDto.Offset).Take(queryDto.Count < 50 ? queryDto.Count : 50).ToListAsync()
            )
        };
    }

    public async Task<CommentLikeRepositoryDto> GetByIdAsync(long id)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<CommentLike,CommentLikeRepositoryDto>());
        var mapper = new Mapper(config);
        var entity = await set.FirstOrDefaultAsync(x => x.Id == id);
        if(entity == null) throw new EntityNotFoundException<CommentLike>(new {id});
        return mapper.Map<CommentLike,CommentLikeRepositoryDto>(entity);
    }

    public async Task UpdateAsync(UpdateCommentLikeRepositoryDto updateDto)
    {
        var entity = await set.FirstOrDefaultAsync(x => x.Id == updateDto.Id);
        if(entity == null) throw new EntityNotFoundException<CommentLike>(new {Id = updateDto.Id});
		if(updateDto.CommentId.HasValue){
            entity.CommentId = updateDto.CommentId.Value;
        }

		if(updateDto.UserId.HasValue){
            entity.UserId = updateDto.UserId.Value;
        }


        await db.SaveChangesAsync();
    }
}