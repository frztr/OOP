
using AutoMapper;
using Microsoft.EntityFrameworkCore;
namespace Global;
public class ReviewRepository(AppDbContext db) : IReviewRepository
{ 
    DbSet<Review> set = db.Set<Review>();
    public async Task<ReviewRepositoryDto> AddAsync(AddReviewRepositoryDto addDto)
    {  
        var config = new MapperConfiguration(cfg => cfg.CreateMap<AddReviewRepositoryDto, Review>());
        var mapper = new Mapper(config);
        var entity = mapper.Map<AddReviewRepositoryDto, Review>(addDto);
        await set.AddAsync(entity);
        await db.SaveChangesAsync();
        var config2 = new MapperConfiguration(cfg => cfg.CreateMap<Review,ReviewRepositoryDto>());
        var mapper2 = new Mapper(config2);
        var dto = mapper2.Map<Review,ReviewRepositoryDto>(entity);
        return dto;
    }

    public async Task DeleteAsync(long id)
    {
        var entity = await set.FirstOrDefaultAsync(x => x.Id == id);
        if(entity == null) throw new EntityNotFoundException<Review>(new {id});
        set.Remove(entity);
        await db.SaveChangesAsync();
    }

    public async Task<ReviewListRepositoryDto> GetAllAsync(ReviewQueryRepositoryDto queryDto)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<Review,ReviewRepositoryDto>());
        var mapper = new Mapper(config);
        return new ReviewListRepositoryDto()
        {
            Items = mapper.Map<List<ReviewRepositoryDto>>(
            await set
.Skip(queryDto.Offset).Take(queryDto.Count < 50 ? queryDto.Count : 50).ToListAsync()
            )
        };
    }

    public async Task<ReviewRepositoryDto> GetByIdAsync(long id)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<Review,ReviewRepositoryDto>());
        var mapper = new Mapper(config);
        var entity = await set.FirstOrDefaultAsync(x => x.Id == id);
        if(entity == null) throw new EntityNotFoundException<Review>(new {id});
        return mapper.Map<Review,ReviewRepositoryDto>(entity);
    }

    public async Task UpdateAsync(UpdateReviewRepositoryDto updateDto)
    {
        var entity = await set.FirstOrDefaultAsync(x => x.Id == updateDto.Id);
        if(entity == null) throw new EntityNotFoundException<Review>(new {Id = updateDto.Id});
		if(updateDto.UserId.HasValue){
            entity.UserId = updateDto.UserId.Value;
        }

		if(updateDto.EventId.HasValue){
            entity.EventId = updateDto.EventId.Value;
        }

		if(updateDto.Rating.HasValue){
            entity.Rating = updateDto.Rating.Value;
        }
		if(!String.IsNullOrEmpty(updateDto.Comment)){
            entity.Comment = updateDto.Comment;
        }

        await db.SaveChangesAsync();
    }
}