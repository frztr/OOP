public class RepositoryCreator
{

    private static string PropUpdater(EntityProp prop)
    {
        if (prop.Type == "string" || prop.Type == "string?")
        {
            return $@"{"\t"}{"\t"}if(!String.IsNullOrEmpty(updateDto.{prop.Name})){{
            entity.{prop.Name} = updateDto.{prop.Name};
        }}";
        }
        if (prop.Type == "int" ||
         prop.Type == "short" ||
          prop.Type == "decimal" ||
           prop.Type == "long" ||
           prop.Type == "DateTime")
        {
            return $@"{"\t"}{"\t"}if(updateDto.{prop.Name}.HasValue){{
            entity.{prop.Name} = updateDto.{prop.Name}.Value;
        }}";
        }
        return "";
    }
    public static string CreateRepository(Entity entity)
    {
        var pk = entity.Props.FirstOrDefault(x => x.PK);
        return $@"
using AutoMapper;
using Microsoft.EntityFrameworkCore;
namespace Global;
public class {entity.Name}Repository(AppDbContext db) : I{entity.Name}Repository
{{ 
    DbSet<{entity.Name}> set = db.Set<{entity.Name}>();
    public async Task<{entity.Name}RepositoryDto> AddAsync(Add{entity.Name}RepositoryDto addDto)
    {{  
        var config = new MapperConfiguration(cfg => cfg.CreateMap<Add{entity.Name}RepositoryDto, {entity.Name}>());
        var mapper = new Mapper(config);
        var entity = mapper.Map<Add{entity.Name}RepositoryDto, {entity.Name}>(addDto);
        await set.AddAsync(entity);
        await db.SaveChangesAsync();
        var config2 = new MapperConfiguration(cfg => cfg.CreateMap<{entity.Name},{entity.Name}RepositoryDto>());
        var mapper2 = new Mapper(config2);
        var dto = mapper2.Map<{entity.Name},{entity.Name}RepositoryDto>(entity);
        return dto;
    }}

    public async Task DeleteAsync({pk.Type} id)
    {{
        set.Remove(await set.FirstOrDefaultAsync(x => x.{pk.Name} == id));
        await db.SaveChangesAsync();
    }}

    public async Task<{entity.Name}ListRepositoryDto> GetAllAsync({entity.Name}QueryRepositoryDto queryDto)
    {{
        var config = new MapperConfiguration(cfg => cfg.CreateMap<{entity.Name},{entity.Name}RepositoryDto>());
        var mapper = new Mapper(config);
        return new {entity.Name}ListRepositoryDto()
        {{
            Items = mapper.Map<List<{entity.Name}RepositoryDto>>(
            await set
{(entity.ExtendedSearch ? String.Join("\n", entity.Props.Select(x =>
        {
            if (x.Type == "int" || x.Type == "decimal" || x.Type == "short" || x.Type == "long" || x.Type == "DateTime")
                return $@"{"\t\t\t"}.Where(x=> queryDto.{x.Name}_GT.HasValue ? x.{x.Name} > queryDto.{x.Name}_GT.Value : true)
            .Where(x=> queryDto.{x.Name}_GTE.HasValue ? x.{x.Name} >= queryDto.{x.Name}_GTE.Value : true)
            .Where(x=> queryDto.{x.Name}_LT.HasValue ? x.{x.Name} < queryDto.{x.Name}_LT.Value : true)
            .Where(x=> queryDto.{x.Name}_LTE.HasValue ? x.{x.Name} <= queryDto.{x.Name}_LTE.Value : true)
            .Where(x=> queryDto.{x.Name}_EQ.HasValue ? x.{x.Name} == queryDto.{x.Name}_EQ.Value : true)";
            if (x.Type == "string")
                return $@"{"\t\t\t"}.Where(x=> !String.IsNullOrEmpty(queryDto.{x.Name}_EQ) ? x.{x.Name} == queryDto.{x.Name}_EQ : true)  
            .Where(x=> !String.IsNullOrEmpty(queryDto.{x.Name}_LIKE) ? (x.{x.Name}!=null?x.{x.Name}.Contains(queryDto.{x.Name}_LIKE):false) : true)";
            return "";
        }).ToList()) : "")}.Skip(queryDto.Offset).Take(queryDto.Count < 50 ? queryDto.Count : 50).ToListAsync()
            )
        }};
    }}

    public async Task<{entity.Name}RepositoryDto> GetByIdAsync({pk.Type} id)
    {{
        var config = new MapperConfiguration(cfg => cfg.CreateMap<{entity.Name},{entity.Name}RepositoryDto>());
        var mapper = new Mapper(config);
        var entity = await set.FirstOrDefaultAsync(x => x.{pk.Name} == id);
        return mapper.Map<{entity.Name},{entity.Name}RepositoryDto>(entity);
    }}

    public async Task UpdateAsync(Update{entity.Name}RepositoryDto updateDto)
    {{
        var entity = await set.FirstOrDefaultAsync(x => x.{pk.Name} == updateDto.{pk.Name});
{String.Join("\n", entity.Props.Where(x=>!x.PK).Select(x => PropUpdater(x)))}
        await db.SaveChangesAsync();
    }}
}}";

    }
}
