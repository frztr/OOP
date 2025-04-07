public class RepositoryInterfaceCreator
{
    public static string CreateRepository(Entity entity)
    {
        var pk = $@"{entity.Props.FirstOrDefault(x => x.Name == "Id").Type}";
        return $@"
        namespace Global;
        public interface I{entity.Name}Repository
{{
    public {entity.Name}ListDto GetAll({pk} count = 50, {pk} offset = 0);

    public {entity.Name}Dto GetById({pk} id);

    public {entity.Name}Dto Add(Add{entity.Name}Dto addDto);

    public void Delete({pk} id);

    public void Update(Update{entity.Name}Dto updateDto);
}}";

    }
}