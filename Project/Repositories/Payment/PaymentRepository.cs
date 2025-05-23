
using AutoMapper;
using Microsoft.EntityFrameworkCore;
namespace Global;
public class PaymentRepository(AppDbContext db) : IPaymentRepository
{ 
    DbSet<Payment> set = db.Set<Payment>();
    public async Task<PaymentRepositoryDto> AddAsync(AddPaymentRepositoryDto addDto)
    {  
        var config = new MapperConfiguration(cfg => cfg.CreateMap<AddPaymentRepositoryDto, Payment>());
        var mapper = new Mapper(config);
        var entity = mapper.Map<AddPaymentRepositoryDto, Payment>(addDto);
        await set.AddAsync(entity);
        await db.SaveChangesAsync();
        var config2 = new MapperConfiguration(cfg => cfg.CreateMap<Payment,PaymentRepositoryDto>());
        var mapper2 = new Mapper(config2);
        var dto = mapper2.Map<Payment,PaymentRepositoryDto>(entity);
        return dto;
    }

    public async Task DeleteAsync(long id)
    {
        var entity = await set.FirstOrDefaultAsync(x => x.Id == id);
        if(entity == null) throw new EntityNotFoundException<Payment>(new {id});
        set.Remove(entity);
        await db.SaveChangesAsync();
    }

    public async Task<PaymentListRepositoryDto> GetAllAsync(PaymentQueryRepositoryDto queryDto)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<Payment,PaymentRepositoryDto>());
        var mapper = new Mapper(config);
        return new PaymentListRepositoryDto()
        {
            Items = mapper.Map<List<PaymentRepositoryDto>>(
            await set
.Skip(queryDto.Offset).Take(queryDto.Count < 50 ? queryDto.Count : 50).ToListAsync()
            )
        };
    }

    public async Task<PaymentRepositoryDto> GetByIdAsync(long id)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<Payment,PaymentRepositoryDto>());
        var mapper = new Mapper(config);
        var entity = await set.FirstOrDefaultAsync(x => x.Id == id);
        if(entity == null) throw new EntityNotFoundException<Payment>(new {id});
        return mapper.Map<Payment,PaymentRepositoryDto>(entity);
    }

    public async Task UpdateAsync(UpdatePaymentRepositoryDto updateDto)
    {
        var entity = await set.FirstOrDefaultAsync(x => x.Id == updateDto.Id);
        if(entity == null) throw new EntityNotFoundException<Payment>(new {Id = updateDto.Id});
		if(updateDto.BookingId.HasValue){
            entity.BookingId = updateDto.BookingId.Value;
        }

		if(updateDto.PaymentDate.HasValue){
            entity.PaymentDate = updateDto.PaymentDate.Value;
        }
		if(updateDto.PaymentMethodId.HasValue){
            entity.PaymentMethodId = updateDto.PaymentMethodId.Value;
        }

		if(updateDto.StatusId.HasValue){
            entity.StatusId = updateDto.StatusId.Value;
        }

        await db.SaveChangesAsync();
    }
}