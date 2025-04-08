
using AutoMapper;
using Microsoft.EntityFrameworkCore;
namespace Global;
public class VehicleDocumentRepository(AppDbContext db) : IVehicleDocumentRepository
{ 
    DbSet<VehicleDocument> set = db.Set<VehicleDocument>();
    public async Task<VehicleDocumentRepositoryDto> AddAsync(AddVehicleDocumentRepositoryDto addDto)
    {  
        var config = new MapperConfiguration(cfg => cfg.CreateMap<AddVehicleDocumentRepositoryDto, VehicleDocument>());
        var mapper = new Mapper(config);
        var entity = mapper.Map<AddVehicleDocumentRepositoryDto, VehicleDocument>(addDto);
        await set.AddAsync(entity);
        await db.SaveChangesAsync();
        var config2 = new MapperConfiguration(cfg => cfg.CreateMap<VehicleDocument,VehicleDocumentRepositoryDto>());
        var mapper2 = new Mapper(config2);
        var dto = mapper2.Map<VehicleDocument,VehicleDocumentRepositoryDto>(entity);
        return dto;
    }

    public async Task DeleteAsync(int id)
    {
        set.Remove(await set.FirstOrDefaultAsync(x => x.Id == id));
        await db.SaveChangesAsync();
    }

    public async Task<VehicleDocumentListRepositoryDto> GetAllAsync(int count = 50, int offset = 0)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<VehicleDocument,VehicleDocumentRepositoryDto>());
        var mapper = new Mapper(config);
        return new VehicleDocumentListRepositoryDto()
        {
            Items = mapper.Map<List<VehicleDocumentRepositoryDto>>(
            await set.Skip(offset).Take(count < 50 ? count : 50).ToListAsync()
            )
        };
    }

    public async Task<VehicleDocumentRepositoryDto> GetByIdAsync(int id)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<VehicleDocument,VehicleDocumentRepositoryDto>());
        var mapper = new Mapper(config);
        var entity = await set.FirstOrDefaultAsync(x => x.Id == id);
        return mapper.Map<VehicleDocument,VehicleDocumentRepositoryDto>(entity);
    }

    public async Task UpdateAsync(UpdateVehicleDocumentRepositoryDto updateDto)
    {
        var entity = await set.FirstOrDefaultAsync(x => x.Id == updateDto.Id);
        var config = new MapperConfiguration(cfg => cfg.CreateMap<UpdateVehicleDocumentRepositoryDto, VehicleDocument>());
        var mapper = new Mapper(config);
        mapper.Map<UpdateVehicleDocumentRepositoryDto, VehicleDocument>(updateDto,entity);
        db.SaveChangesAsync();
    }
}