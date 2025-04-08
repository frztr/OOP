public class RepositoryInterfaceCreator
{
    public static string CreateRepository(Entity entity)
    {
        var pk = $@"{entity.Props.FirstOrDefault(x => x.PK).Type}";
        return $@"
        namespace Global;
        public interface I{entity.Name}Repository
{{
    public Task<{entity.Name}ListRepositoryDto> GetAllAsync({pk} count = 50, {pk} offset = 0);

    public Task<{entity.Name}RepositoryDto> GetByIdAsync({pk} id);

    public Task<{entity.Name}RepositoryDto> AddAsync(Add{entity.Name}RepositoryDto addDto);

    public Task DeleteAsync({pk} id);

    public Task UpdateAsync(Update{entity.Name}RepositoryDto updateDto);
}}";

    }
}