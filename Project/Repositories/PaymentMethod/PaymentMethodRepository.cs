
using AutoMapper;
using Microsoft.EntityFrameworkCore;
namespace Global;
public class PaymentMethodRepository(AppDbContext db) : IPaymentMethodRepository
{ 
    DbSet<PaymentMethod> set = db.Set<PaymentMethod>();
    public async Task<PaymentMethodRepositoryDto> AddAsync(AddPaymentMethodRepositoryDto addDto)
    {  
        var config = new MapperConfiguration(cfg => cfg.CreateMap<AddPaymentMethodRepositoryDto, PaymentMethod>());
        var mapper = new Mapper(config);
        var entity = mapper.Map<AddPaymentMethodRepositoryDto, PaymentMethod>(addDto);
        await set.AddAsync(entity);
        await db.SaveChangesAsync();
        var config2 = new MapperConfiguration(cfg => cfg.CreateMap<PaymentMethod,PaymentMethodRepositoryDto>());
        var mapper2 = new Mapper(config2);
        var dto = mapper2.Map<PaymentMethod,PaymentMethodRepositoryDto>(entity);
        return dto;
    }

    public async Task DeleteAsync(short id)
    {
        var entity = await set.FirstOrDefaultAsync(x => x.Id == id);
        if(entity == null) throw new EntityNotFoundException<PaymentMethod>(new {id});
        set.Remove(entity);
        await db.SaveChangesAsync();
    }

    public async Task<PaymentMethodListRepositoryDto> GetAllAsync(PaymentMethodQueryRepositoryDto queryDto)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<PaymentMethod,PaymentMethodRepositoryDto>());
        var mapper = new Mapper(config);
        return new PaymentMethodListRepositoryDto()
        {
            Items = mapper.Map<List<PaymentMethodRepositoryDto>>(
            await set
.Skip(queryDto.Offset).Take(queryDto.Count < 50 ? queryDto.Count : 50).ToListAsync()
            )
        };
    }

    public async Task<PaymentMethodRepositoryDto> GetByIdAsync(short id)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<PaymentMethod,PaymentMethodRepositoryDto>());
        var mapper = new Mapper(config);
        var entity = await set.FirstOrDefaultAsync(x => x.Id == id);
        if(entity == null) throw new EntityNotFoundException<PaymentMethod>(new {id});
        return mapper.Map<PaymentMethod,PaymentMethodRepositoryDto>(entity);
    }

    public async Task UpdateAsync(UpdatePaymentMethodRepositoryDto updateDto)
    {
        var entity = await set.FirstOrDefaultAsync(x => x.Id == updateDto.Id);
        if(entity == null) throw new EntityNotFoundException<PaymentMethod>(new {Id = updateDto.Id});
		if(!String.IsNullOrEmpty(updateDto.Name)){
            entity.Name = updateDto.Name;
        }

        await db.SaveChangesAsync();
    }
}