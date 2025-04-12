
using AutoMapper;
using Microsoft.EntityFrameworkCore;
namespace Global;
public class SparePartRepository(AppDbContext db) : ISparePartRepository
{ 
    DbSet<SparePart> set = db.Set<SparePart>();
    public async Task<SparePartRepositoryDto> AddAsync(AddSparePartRepositoryDto addDto)
    {  
        var config = new MapperConfiguration(cfg => cfg.CreateMap<AddSparePartRepositoryDto, SparePart>());
        var mapper = new Mapper(config);
        var entity = mapper.Map<AddSparePartRepositoryDto, SparePart>(addDto);
        await set.AddAsync(entity);
        await db.SaveChangesAsync();
        var config2 = new MapperConfiguration(cfg => cfg.CreateMap<SparePart,SparePartRepositoryDto>());
        var mapper2 = new Mapper(config2);
        var dto = mapper2.Map<SparePart,SparePartRepositoryDto>(entity);
        return dto;
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await set.FirstOrDefaultAsync(x => x.Id == id);
        if(entity == null) throw new EntityNotFoundException<SparePart>(new {id});
        set.Remove(entity);
        await db.SaveChangesAsync();
    }

    public async Task<SparePartListRepositoryDto> GetAllAsync(SparePartQueryRepositoryDto queryDto)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<SparePart,SparePartRepositoryDto>());
        var mapper = new Mapper(config);
        return new SparePartListRepositoryDto()
        {
            Items = mapper.Map<List<SparePartRepositoryDto>>(
            await set
.Skip(queryDto.Offset).Take(queryDto.Count < 50 ? queryDto.Count : 50).ToListAsync()
            )
        };
    }

    public async Task<SparePartRepositoryDto> GetByIdAsync(int id)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<SparePart,SparePartRepositoryDto>());
        var mapper = new Mapper(config);
        var entity = await set.FirstOrDefaultAsync(x => x.Id == id);
        if(entity == null) throw new EntityNotFoundException<SparePart>(new {id});
        return mapper.Map<SparePart,SparePartRepositoryDto>(entity);
    }

    public async Task UpdateAsync(UpdateSparePartRepositoryDto updateDto)
    {
        var entity = await set.FirstOrDefaultAsync(x => x.Id == updateDto.Id);
        if(entity == null) throw new EntityNotFoundException<SparePart>(new {Id = updateDto.Id});
		if(!String.IsNullOrEmpty(updateDto.Name)){
            entity.Name = updateDto.Name;
        }
		if(updateDto.CountLeft.HasValue){
            entity.CountLeft = updateDto.CountLeft.Value;
        }
        await db.SaveChangesAsync();
    }
}