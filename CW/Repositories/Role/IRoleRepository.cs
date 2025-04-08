
        namespace Global;
        public interface IRoleRepository
{
    public Task<RoleListRepositoryDto> GetAllAsync(short count = 50, short offset = 0);

    public Task<RoleRepositoryDto> GetByIdAsync(short id);

    public Task<RoleRepositoryDto> AddAsync(AddRoleRepositoryDto addDto);

    public Task DeleteAsync(short id);

    public Task UpdateAsync(UpdateRoleRepositoryDto updateDto);
}