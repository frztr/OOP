
using AutoMapper;
using Microsoft.EntityFrameworkCore;
namespace Global;
public class PaymentStatusRepository(AppDbContext db) : IPaymentStatusRepository
{ 
    DbSet<PaymentStatus> set = db.Set<PaymentStatus>();
    public async Task<PaymentStatusRepositoryDto> AddAsync(AddPaymentStatusRepositoryDto addDto)
    {  
        var config = new MapperConfiguration(cfg => cfg.CreateMap<AddPaymentStatusRepositoryDto, PaymentStatus>());
        var mapper = new Mapper(config);
        var entity = mapper.Map<AddPaymentStatusRepositoryDto, PaymentStatus>(addDto);
        await set.AddAsync(entity);
        await db.SaveChangesAsync();
        var config2 = new MapperConfiguration(cfg => cfg.CreateMap<PaymentStatus,PaymentStatusRepositoryDto>());
        var mapper2 = new Mapper(config2);
        var dto = mapper2.Map<PaymentStatus,PaymentStatusRepositoryDto>(entity);
        return dto;
    }

    public async Task DeleteAsync(short id)
    {
        var entity = await set.FirstOrDefaultAsync(x => x.Id == id);
        if(entity == null) throw new EntityNotFoundException<PaymentStatus>(new {id});
        set.Remove(entity);
        await db.SaveChangesAsync();
    }

    public async Task<PaymentStatusListRepositoryDto> GetAllAsync(PaymentStatusQueryRepositoryDto queryDto)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<PaymentStatus,PaymentStatusRepositoryDto>());
        var mapper = new Mapper(config);
        return new PaymentStatusListRepositoryDto()
        {
            Items = mapper.Map<List<PaymentStatusRepositoryDto>>(
            await set
.Skip(queryDto.Offset).Take(queryDto.Count < 50 ? queryDto.Count : 50).ToListAsync()
            )
        };
    }

    public async Task<PaymentStatusRepositoryDto> GetByIdAsync(short id)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<PaymentStatus,PaymentStatusRepositoryDto>());
        var mapper = new Mapper(config);
        var entity = await set.FirstOrDefaultAsync(x => x.Id == id);
        if(entity == null) throw new EntityNotFoundException<PaymentStatus>(new {id});
        return mapper.Map<PaymentStatus,PaymentStatusRepositoryDto>(entity);
    }

    public async Task UpdateAsync(UpdatePaymentStatusRepositoryDto updateDto)
    {
        var entity = await set.FirstOrDefaultAsync(x => x.Id == updateDto.Id);
        if(entity == null) throw new EntityNotFoundException<PaymentStatus>(new {Id = updateDto.Id});
		if(!String.IsNullOrEmpty(updateDto.Name)){
            entity.Name = updateDto.Name;
        }

        await db.SaveChangesAsync();
    }
}