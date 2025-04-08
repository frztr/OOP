
namespace Global;
public interface IRoleService
    {
        public Task<RoleListServiceDto> GetAllAsync(short count = 50, short offset = 0);

        public Task<RoleServiceDto> GetByIdAsync(short id);

        public Task<RoleServiceDto> AddAsync(AddRoleServiceDto addDto);

        public Task DeleteAsync(short id);

        public Task UpdateAsync(UpdateRoleServiceDto updateDto);
    }