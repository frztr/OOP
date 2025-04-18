
using AutoMapper;
using Microsoft.EntityFrameworkCore;
namespace Global;
public class RepairHistoryRepository(AppDbContext db) : IRepairHistoryRepository
{ 
    DbSet<RepairHistory> set = db.Set<RepairHistory>();
    public async Task<RepairHistoryRepositoryDto> AddAsync(AddRepairHistoryRepositoryDto addDto)
    {  
        var config = new MapperConfiguration(cfg => cfg.CreateMap<AddRepairHistoryRepositoryDto, RepairHistory>());
        var mapper = new Mapper(config);
        var entity = mapper.Map<AddRepairHistoryRepositoryDto, RepairHistory>(addDto);
        await set.AddAsync(entity);
        await db.SaveChangesAsync();
        var config2 = new MapperConfiguration(cfg => cfg.CreateMap<RepairHistory,RepairHistoryRepositoryDto>());
        var mapper2 = new Mapper(config2);
        var dto = mapper2.Map<RepairHistory,RepairHistoryRepositoryDto>(entity);
        return dto;
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await set.FirstOrDefaultAsync(x => x.Id == id);
        if(entity == null) throw new EntityNotFoundException<RepairHistory>(new {id});
        set.Remove(entity);
        await db.SaveChangesAsync();
    }

    public async Task<RepairHistoryListRepositoryDto> GetAllAsync(RepairHistoryQueryRepositoryDto queryDto)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<RepairHistory,RepairHistoryRepositoryDto>());
        var mapper = new Mapper(config);
        return new RepairHistoryListRepositoryDto()
        {
            Items = mapper.Map<List<RepairHistoryRepositoryDto>>(
            await set
			.Where(x=> queryDto.Id_GT.HasValue ? x.Id > queryDto.Id_GT.Value : true)
            .Where(x=> queryDto.Id_GTE.HasValue ? x.Id >= queryDto.Id_GTE.Value : true)
            .Where(x=> queryDto.Id_LT.HasValue ? x.Id < queryDto.Id_LT.Value : true)
            .Where(x=> queryDto.Id_LTE.HasValue ? x.Id <= queryDto.Id_LTE.Value : true)
            .Where(x=> queryDto.Id_EQ.HasValue ? x.Id == queryDto.Id_EQ.Value : true)
			.Where(x=> queryDto.VehicleId_GT.HasValue ? x.VehicleId > queryDto.VehicleId_GT.Value : true)
            .Where(x=> queryDto.VehicleId_GTE.HasValue ? x.VehicleId >= queryDto.VehicleId_GTE.Value : true)
            .Where(x=> queryDto.VehicleId_LT.HasValue ? x.VehicleId < queryDto.VehicleId_LT.Value : true)
            .Where(x=> queryDto.VehicleId_LTE.HasValue ? x.VehicleId <= queryDto.VehicleId_LTE.Value : true)
            .Where(x=> queryDto.VehicleId_EQ.HasValue ? x.VehicleId == queryDto.VehicleId_EQ.Value : true)

			.Where(x=> queryDto.DatetimeBegin_GT.HasValue ? x.DatetimeBegin > queryDto.DatetimeBegin_GT.Value : true)
            .Where(x=> queryDto.DatetimeBegin_GTE.HasValue ? x.DatetimeBegin >= queryDto.DatetimeBegin_GTE.Value : true)
            .Where(x=> queryDto.DatetimeBegin_LT.HasValue ? x.DatetimeBegin < queryDto.DatetimeBegin_LT.Value : true)
            .Where(x=> queryDto.DatetimeBegin_LTE.HasValue ? x.DatetimeBegin <= queryDto.DatetimeBegin_LTE.Value : true)
            .Where(x=> queryDto.DatetimeBegin_EQ.HasValue ? x.DatetimeBegin == queryDto.DatetimeBegin_EQ.Value : true)

			.Where(x=> !String.IsNullOrEmpty(queryDto.CompletedWork_EQ) ? x.CompletedWork == queryDto.CompletedWork_EQ : true)  
            .Where(x=> !String.IsNullOrEmpty(queryDto.CompletedWork_LIKE) ? (x.CompletedWork!=null?x.CompletedWork.Contains(queryDto.CompletedWork_LIKE):false) : true)




.Skip(queryDto.Offset).Take(queryDto.Count < 50 ? queryDto.Count : 50).ToListAsync()
            )
        };
    }

    public async Task<RepairHistoryRepositoryDto> GetByIdAsync(int id)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<RepairHistory,RepairHistoryRepositoryDto>());
        var mapper = new Mapper(config);
        var entity = await set.FirstOrDefaultAsync(x => x.Id == id);
        if(entity == null) throw new EntityNotFoundException<RepairHistory>(new {id});
        return mapper.Map<RepairHistory,RepairHistoryRepositoryDto>(entity);
    }

    public async Task UpdateAsync(UpdateRepairHistoryRepositoryDto updateDto)
    {
        var entity = await set.FirstOrDefaultAsync(x => x.Id == updateDto.Id);
        if(entity == null) throw new EntityNotFoundException<RepairHistory>(new {Id = updateDto.Id});
		if(updateDto.VehicleId.HasValue){
            entity.VehicleId = updateDto.VehicleId.Value;
        }

		if(updateDto.DatetimeBegin.HasValue){
            entity.DatetimeBegin = updateDto.DatetimeBegin.Value;
        }

		if(!String.IsNullOrEmpty(updateDto.CompletedWork)){
            entity.CompletedWork = updateDto.CompletedWork;
        }





        await db.SaveChangesAsync();
    }
}