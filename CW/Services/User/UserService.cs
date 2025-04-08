
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using AutoMapper;
namespace Global;
public class UserService(IUserRepository repository) : IUserService
{
    public async Task<UserServiceDto> AddAsync(AddUserServiceDto addServiceDto)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<AddUserServiceDto, AddUserRepositoryDto>());
        var mapper = new Mapper(config);
        var addRepositoryDto = mapper.Map<AddUserServiceDto, AddUserRepositoryDto>(addServiceDto);
        addRepositoryDto.PasswordHash = Convert.ToHexString(MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(addServiceDto.Password))).ToLower();
        var entityRepositoryDto = await repository.AddAsync(addRepositoryDto);
        var config2 = new MapperConfiguration(cfg => cfg.CreateMap<UserRepositoryDto, UserServiceDto>());
        var mapper2 = new Mapper(config2);
        return mapper2.Map<UserRepositoryDto, UserServiceDto>(entityRepositoryDto);
    }

    public async Task DeleteAsync(short id)
    {
        await repository.DeleteAsync(id);
    }

    public async Task<UserListServiceDto> GetAllAsync(short count = 50, short offset = 0)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<UserRepositoryDto,UserServiceDto>());
        var mapper = new Mapper(config);
        return new UserListServiceDto(){
            Items = (await repository.GetAllAsync(count, offset)).Items.Select(x=>mapper.Map<UserServiceDto>(x))
        };
    }

    public async Task<UserServiceDto> GetByIdAsync(short id)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<UserRepositoryDto, UserServiceDto>());
        var mapper = new Mapper(config);
        return mapper.Map<UserRepositoryDto, UserServiceDto>(await repository.GetByIdAsync(id));
    }

    public async Task UpdateAsync(UpdateUserServiceDto updateDto)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<UpdateUserServiceDto, UpdateUserRepositoryDto>());
        var mapper = new Mapper(config);
        var updateRepositoryDto = mapper.Map<UpdateUserServiceDto, UpdateUserRepositoryDto>(updateDto);
        await repository.UpdateAsync(updateRepositoryDto);
    }

    public async Task<UserLoginResultServiceDto> Login(UserLoginServiceDto loginDto)
    {
        var passwordHash = Convert.ToHexString(MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password))).ToLower();
        var credentials = await repository.Login(new UserLoginRepositoryDto(){
            Login = loginDto.Login,
            PasswordHash = passwordHash
        });
        var claims = new List<Claim> {
                new Claim("id", credentials.Id.ToString()),
                new Claim(ClaimTypes.Name, credentials.Login),
                new Claim(ClaimTypes.Role, credentials.RoleName)
                };
        var jwt = new JwtSecurityToken(
                issuer: "CW",
                audience: "CW",
                claims: claims,
                expires: DateTime.UtcNow.Add(TimeSpan.FromDays(90)),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("J9gGkPrHnbT6rZHjkiaGLvFpRGkEMMDr")), SecurityAlgorithms.HmacSha256));

        return new UserLoginResultServiceDto(){
            Token = new JwtSecurityTokenHandler().WriteToken(jwt)
        };
    }
}