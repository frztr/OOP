public class UserRepositoryInterfaceCreator
{
    public static string CreateRepository(Entity entity)
    {
        var pk = $@"{entity.Props.FirstOrDefault(x => x.PK).Type}";
        return $@"
        namespace Global;
        public interface I{entity.Name}Repository
{{
    public Task<{entity.Name}ListRepositoryDto> GetAllAsync({entity.Name}QueryRepositoryDto queryDto);

    public Task<{entity.Name}RepositoryDto> GetByIdAsync({pk} id);

    public Task<{entity.Name}RepositoryDto> AddAsync(Add{entity.Name}RepositoryDto addDto);

    public Task DeleteAsync({pk} id);

    public Task UpdateAsync(Update{entity.Name}RepositoryDto updateDto);

    public Task<UserLoginResultRepositoryDto> Login(UserLoginRepositoryDto loginDto);
}}";

    }
}