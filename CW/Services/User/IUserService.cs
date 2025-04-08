
namespace Global;
public interface IUserService
    {
        public Task<UserListServiceDto> GetAllAsync(short count = 50, short offset = 0);

        public Task<UserServiceDto> GetByIdAsync(short id);

        public Task<UserServiceDto> AddAsync(AddUserServiceDto addDto);

        public Task DeleteAsync(short id);

        public Task UpdateAsync(UpdateUserServiceDto updateDto);

        public Task<UserLoginResultServiceDto> Login(UserLoginServiceDto loginDto);
    }