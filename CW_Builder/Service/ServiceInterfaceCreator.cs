public class ServiceInterfaceCreator
{
    public static string CreateService(Entity entity)
    {
        var pk = $@"{entity.Props.FirstOrDefault(x => x.PK).Type}";
        return $@"
namespace Global;
public interface I{entity.Name}Service
    {{
        public Task<{entity.Name}ListServiceDto> GetAllAsync({pk} count = 50, {pk} offset = 0);

        public Task<{entity.Name}ServiceDto> GetByIdAsync({pk} id);

        public Task<{entity.Name}ServiceDto> AddAsync(Add{entity.Name}ServiceDto addDto);

        public Task DeleteAsync({pk} id);

        public Task UpdateAsync(Update{entity.Name}ServiceDto updateDto);
    }}";

    }
}