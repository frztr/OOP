
using AutoMapper;
using Microsoft.EntityFrameworkCore;
namespace Global;
public class BookingRepository(AppDbContext db) : IBookingRepository
{ 
    DbSet<Booking> set = db.Set<Booking>();
    public async Task<BookingRepositoryDto> AddAsync(AddBookingRepositoryDto addDto)
    {  
        var config = new MapperConfiguration(cfg => cfg.CreateMap<AddBookingRepositoryDto, Booking>());
        var mapper = new Mapper(config);
        var entity = mapper.Map<AddBookingRepositoryDto, Booking>(addDto);
        await set.AddAsync(entity);
        await db.SaveChangesAsync();
        var config2 = new MapperConfiguration(cfg => cfg.CreateMap<Booking,BookingRepositoryDto>());
        var mapper2 = new Mapper(config2);
        var dto = mapper2.Map<Booking,BookingRepositoryDto>(entity);
        return dto;
    }

    public async Task DeleteAsync(long id)
    {
        var entity = await set.FirstOrDefaultAsync(x => x.Id == id);
        if(entity == null) throw new EntityNotFoundException<Booking>(new {id});
        set.Remove(entity);
        await db.SaveChangesAsync();
    }

    public async Task<BookingListRepositoryDto> GetAllAsync(BookingQueryRepositoryDto queryDto)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<Booking,BookingRepositoryDto>());
        var mapper = new Mapper(config);
        return new BookingListRepositoryDto()
        {
            Items = mapper.Map<List<BookingRepositoryDto>>(
            await set
.Skip(queryDto.Offset).Take(queryDto.Count < 50 ? queryDto.Count : 50).ToListAsync()
            )
        };
    }

    public async Task<BookingRepositoryDto> GetByIdAsync(long id)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<Booking,BookingRepositoryDto>());
        var mapper = new Mapper(config);
        var entity = await set.FirstOrDefaultAsync(x => x.Id == id);
        if(entity == null) throw new EntityNotFoundException<Booking>(new {id});
        return mapper.Map<Booking,BookingRepositoryDto>(entity);
    }

    public async Task UpdateAsync(UpdateBookingRepositoryDto updateDto)
    {
        var entity = await set.FirstOrDefaultAsync(x => x.Id == updateDto.Id);
        if(entity == null) throw new EntityNotFoundException<Booking>(new {Id = updateDto.Id});
		if(updateDto.UserId.HasValue){
            entity.UserId = updateDto.UserId.Value;
        }

		if(updateDto.EventId.HasValue){
            entity.EventId = updateDto.EventId.Value;
        }

		if(updateDto.BookingDate.HasValue){
            entity.BookingDate = updateDto.BookingDate.Value;
        }


		if(updateDto.NumberOfSeats.HasValue){
            entity.NumberOfSeats = updateDto.NumberOfSeats.Value;
        }

        await db.SaveChangesAsync();
    }
}