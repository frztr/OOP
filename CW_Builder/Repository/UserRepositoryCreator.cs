public class UserRepositoryCreator
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
            await set.Skip(queryDto.Offset).Take(queryDto.Count < 50 ? queryDto.Count : 50).ToListAsync()
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
        var config = new MapperConfiguration(cfg => cfg.CreateMap<Update{entity.Name}RepositoryDto, {entity.Name}>());
        var mapper = new Mapper(config);
        mapper.Map<Update{entity.Name}RepositoryDto, {entity.Name}>(updateDto,entity);
        db.SaveChangesAsync();
    }}

    public async Task<UserLoginResultRepositoryDto> Login(UserLoginRepositoryDto loginDto)
    {{
        var entity = await set.Include(x=>x.Role).FirstOrDefaultAsync(x=>x.Login == loginDto.Login && x.PasswordHash == loginDto.PasswordHash);
        var config = new MapperConfiguration(cfg => cfg.CreateMap<User, UserLoginResultRepositoryDto>());
        var mapper = new Mapper(config);
        var resultDto = mapper.Map<User, UserLoginResultRepositoryDto>(entity);
        resultDto.RoleName = entity.Role.Name;
        return resultDto;
    }}
}}";

    }
}