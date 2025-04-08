
        namespace Global;
        public interface IUserRepository
{
    public Task<UserListRepositoryDto> GetAllAsync(short count = 50, short offset = 0);

    public Task<UserRepositoryDto> GetByIdAsync(short id);

    public Task<UserRepositoryDto> AddAsync(AddUserRepositoryDto addDto);

    public Task DeleteAsync(short id);

    public Task UpdateAsync(UpdateUserRepositoryDto updateDto);

    public Task<UserLoginResultRepositoryDto> Login(UserLoginRepositoryDto loginDto);
}