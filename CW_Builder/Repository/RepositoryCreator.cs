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
        var pk = $@"{entity.Props.FirstOrDefault(x => x.Name == "Id").Type}";
        return $@"
using Microsoft.EntityFrameworkCore;
namespace Global;
public class {entity.Name}Repository(AppDbContext db) : I{entity.Name}Repository
{{ 
    DbSet<{entity.Name}> set = db.Set<{entity.Name}>();
    public {entity.Name}Dto Add(Add{entity.Name}Dto addDto)
    {{  
        {entity.Name} entity = new {entity.Name}(){{
{String.Join(",\n", entity.Props.Where(x => AppContext.Get().AllowedValues.Contains(x.Type))
            .Where(x => x.Name != "Id")
            .Select(x => $"\t\t\t{x.Name} = addDto.{x.Name}"))}
        }};
        set.Add(entity);
        db.SaveChanges();
        return new {entity.Name}Dto(){{
{String.Join(",\n", entity.Props.Where(x => AppContext.Get().AllowedValues.Contains(x.Type))
            .Select(x => $"\t\t\t{x.Name} = entity.{x.Name}"))}
        }};
    }}

    public void Delete({pk} id)
    {{
        set.ToList().Remove(set.FirstOrDefault(x => x.Id == id));
        db.SaveChanges();
    }}

    public {entity.Name}ListDto GetAll({pk} count = 50, {pk} offset = 0)
    {{
        return new {entity.Name}ListDto()
        {{
            items = set.Skip(offset).Take(count < 50 ? count : 50).ToList().Select(x => new {entity.Name}Dto(){{
{String.Join(",\n", entity.Props.Where(x => AppContext.Get().AllowedValues.Contains(x.Type))
            .Select(x => $"\t\t\t\t{x.Name} = x.{x.Name}"))}
            }})
        }};
    }}

    public {entity.Name}Dto GetById({pk} id)
    {{
        var entity = set.FirstOrDefault(x => x.Id == id);
        return new {entity.Name}Dto(){{
{String.Join(",\n", entity.Props.Where(x => AppContext.Get().AllowedValues.Contains(x.Type))
            .Select(x => $"\t\t\t{x.Name} = entity.{x.Name}"))}
        }};
    }}

    public void Update(Update{entity.Name}Dto updateDto)
    {{
        var entity = set.FirstOrDefault(x => x.Id == updateDto.Id);
{String.Join("\n", entity.Props.Where(x => x.Name != "Id").Where(x => AppContext.Get().AllowedValues.Contains(x.Type))
        .Select(x => PropUpdater(x)))}
        db.SaveChanges();
    }}
}}";

    }
}
