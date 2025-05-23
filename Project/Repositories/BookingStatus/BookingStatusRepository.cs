
using AutoMapper;
using Microsoft.EntityFrameworkCore;
namespace Global;
public class BookingStatusRepository(AppDbContext db) : IBookingStatusRepository
{ 
    DbSet<BookingStatus> set = db.Set<BookingStatus>();
    public async Task<BookingStatusRepositoryDto> AddAsync(AddBookingStatusRepositoryDto addDto)
    {  
        var config = new MapperConfiguration(cfg => cfg.CreateMap<AddBookingStatusRepositoryDto, BookingStatus>());
        var mapper = new Mapper(config);
        var entity = mapper.Map<AddBookingStatusRepositoryDto, BookingStatus>(addDto);
        await set.AddAsync(entity);
        await db.SaveChangesAsync();
        var config2 = new MapperConfiguration(cfg => cfg.CreateMap<BookingStatus,BookingStatusRepositoryDto>());
        var mapper2 = new Mapper(config2);
        var dto = mapper2.Map<BookingStatus,BookingStatusRepositoryDto>(entity);
        return dto;
    }

    public async Task DeleteAsync(short id)
    {
        var entity = await set.FirstOrDefaultAsync(x => x.Id == id);
        if(entity == null) throw new EntityNotFoundException<BookingStatus>(new {id});
        set.Remove(entity);
        await db.SaveChangesAsync();
    }

    public async Task<BookingStatusListRepositoryDto> GetAllAsync(BookingStatusQueryRepositoryDto queryDto)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<BookingStatus,BookingStatusRepositoryDto>());
        var mapper = new Mapper(config);
        return new BookingStatusListRepositoryDto()
        {
            Items = mapper.Map<List<BookingStatusRepositoryDto>>(
            await set
.Skip(queryDto.Offset).Take(queryDto.Count < 50 ? queryDto.Count : 50).ToListAsync()
            )
        };
    }

    public async Task<BookingStatusRepositoryDto> GetByIdAsync(short id)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<BookingStatus,BookingStatusRepositoryDto>());
        var mapper = new Mapper(config);
        var entity = await set.FirstOrDefaultAsync(x => x.Id == id);
        if(entity == null) throw new EntityNotFoundException<BookingStatus>(new {id});
        return mapper.Map<BookingStatus,BookingStatusRepositoryDto>(entity);
    }

    public async Task UpdateAsync(UpdateBookingStatusRepositoryDto updateDto)
    {
        var entity = await set.FirstOrDefaultAsync(x => x.Id == updateDto.Id);
        if(entity == null) throw new EntityNotFoundException<BookingStatus>(new {Id = updateDto.Id});
		if(!String.IsNullOrEmpty(updateDto.Name)){
            entity.Name = updateDto.Name;
        }

        await db.SaveChangesAsync();
    }
}