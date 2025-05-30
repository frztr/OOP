
using AutoMapper;
using Microsoft.EntityFrameworkCore;
namespace Global;
public class CommentRepository(AppDbContext db) : ICommentRepository
{ 
    DbSet<Comment> set = db.Set<Comment>();
    public async Task<CommentRepositoryDto> AddAsync(AddCommentRepositoryDto addDto)
    {  
        var config = new MapperConfiguration(cfg => cfg.CreateMap<AddCommentRepositoryDto, Comment>());
        var mapper = new Mapper(config);
        var entity = mapper.Map<AddCommentRepositoryDto, Comment>(addDto);
        await set.AddAsync(entity);
        await db.SaveChangesAsync();
        var config2 = new MapperConfiguration(cfg => cfg.CreateMap<Comment,CommentRepositoryDto>());
        var mapper2 = new Mapper(config2);
        var dto = mapper2.Map<Comment,CommentRepositoryDto>(entity);
        return dto;
    }

    public async Task DeleteAsync(long id)
    {
        var entity = await set.FirstOrDefaultAsync(x => x.Id == id);
        if(entity == null) throw new EntityNotFoundException<Comment>(new {id});
        set.Remove(entity);
        await db.SaveChangesAsync();
    }

    public async Task<CommentListRepositoryDto> GetAllAsync(CommentQueryRepositoryDto queryDto)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<Comment,CommentRepositoryDto>());
        var mapper = new Mapper(config);
        return new CommentListRepositoryDto()
        {
            Items = mapper.Map<List<CommentRepositoryDto>>(
            await set
.Skip(queryDto.Offset).Take(queryDto.Count < 50 ? queryDto.Count : 50).ToListAsync()
            )
        };
    }

    public async Task<CommentRepositoryDto> GetByIdAsync(long id)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<Comment,CommentRepositoryDto>());
        var mapper = new Mapper(config);
        var entity = await set.FirstOrDefaultAsync(x => x.Id == id);
        if(entity == null) throw new EntityNotFoundException<Comment>(new {id});
        return mapper.Map<Comment,CommentRepositoryDto>(entity);
    }

    public async Task UpdateAsync(UpdateCommentRepositoryDto updateDto)
    {
        var entity = await set.FirstOrDefaultAsync(x => x.Id == updateDto.Id);
        if(entity == null) throw new EntityNotFoundException<Comment>(new {Id = updateDto.Id});
		if(updateDto.PostId.HasValue){
            entity.PostId = updateDto.PostId.Value;
        }

		if(updateDto.UserId.HasValue){
            entity.UserId = updateDto.UserId.Value;
        }



		if(!String.IsNullOrEmpty(updateDto.Content)){
            entity.Content = updateDto.Content;
        }




        await db.SaveChangesAsync();
    }
}