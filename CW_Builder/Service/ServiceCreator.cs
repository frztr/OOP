public class ServiceCreator
{
    public static string CreateService(Entity entity)
    {
        var pk = $@"{entity.Props.FirstOrDefault(x => x.Name == "Id").Type}";
        return $@"
namespace Global;
public class {entity.Name}Service(I{entity.Name}Repository repository) : I{entity.Name}Service
{{
    public {entity.Name}Dto Add(Add{entity.Name}Dto addDto)
    {{
        return repository.Add(addDto);
    }}

    public void Delete({pk} id)
    {{
        repository.Delete(id);
    }}

    public {entity.Name}ListDto GetAll({pk} count = 50, {pk} offset = 0)
    {{
        return repository.GetAll(count, offset);
    }}

    public {entity.Name}Dto GetById({pk} id)
    {{
        return repository.GetById(id);
    }}

    public void Update(Update{entity.Name}Dto updateDto)
    {{
        repository.Update(updateDto);
    }}
}}";
    }
}