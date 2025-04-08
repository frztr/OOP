public class UserServiceCreator
{
    public static string CreateService(Entity entity)
    {
        var pk = $@"{entity.Props.FirstOrDefault(x => x.PK).Type}";
        return $@"
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using AutoMapper;
namespace Global;
public class {entity.Name}Service(I{entity.Name}Repository repository) : I{entity.Name}Service
{{
    public async Task<{entity.Name}ServiceDto> AddAsync(Add{entity.Name}ServiceDto addServiceDto)
    {{
        var config = new MapperConfiguration(cfg => cfg.CreateMap<Add{entity.Name}ServiceDto, Add{entity.Name}RepositoryDto>());
        var mapper = new Mapper(config);
        var addRepositoryDto = mapper.Map<Add{entity.Name}ServiceDto, Add{entity.Name}RepositoryDto>(addServiceDto);
        addRepositoryDto.PasswordHash = Convert.ToHexString(MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(addServiceDto.Password))).ToLower();
        var entityRepositoryDto = await repository.AddAsync(addRepositoryDto);
        var config2 = new MapperConfiguration(cfg => cfg.CreateMap<{entity.Name}RepositoryDto, {entity.Name}ServiceDto>());
        var mapper2 = new Mapper(config2);
        return mapper2.Map<{entity.Name}RepositoryDto, {entity.Name}ServiceDto>(entityRepositoryDto);
    }}

    public async Task DeleteAsync({pk} id)
    {{
        await repository.DeleteAsync(id);
    }}

    public async Task<{entity.Name}ListServiceDto> GetAllAsync({pk} count = 50, {pk} offset = 0)
    {{
        var config = new MapperConfiguration(cfg => cfg.CreateMap<{entity.Name}RepositoryDto,{entity.Name}ServiceDto>());
        var mapper = new Mapper(config);
        return new {entity.Name}ListServiceDto(){{
            Items = (await repository.GetAllAsync(count, offset)).Items.Select(x=>mapper.Map<{entity.Name}ServiceDto>(x))
        }};
    }}

    public async Task<{entity.Name}ServiceDto> GetByIdAsync({pk} id)
    {{
        var config = new MapperConfiguration(cfg => cfg.CreateMap<{entity.Name}RepositoryDto, {entity.Name}ServiceDto>());
        var mapper = new Mapper(config);
        return mapper.Map<{entity.Name}RepositoryDto, {entity.Name}ServiceDto>(await repository.GetByIdAsync(id));
    }}

    public async Task UpdateAsync(Update{entity.Name}ServiceDto updateDto)
    {{
        var config = new MapperConfiguration(cfg => cfg.CreateMap<Update{entity.Name}ServiceDto, Update{entity.Name}RepositoryDto>());
        var mapper = new Mapper(config);
        var updateRepositoryDto = mapper.Map<Update{entity.Name}ServiceDto, Update{entity.Name}RepositoryDto>(updateDto);
        await repository.UpdateAsync(updateRepositoryDto);
    }}

    public async Task<UserLoginResultServiceDto> Login(UserLoginServiceDto loginDto)
    {{
        var passwordHash = Convert.ToHexString(MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password))).ToLower();
        var credentials = await repository.Login(new UserLoginRepositoryDto(){{
            Login = loginDto.Login,
            PasswordHash = passwordHash
        }});
        var claims = new List<Claim> {{
                new Claim(""id"", credentials.Id.ToString()),
                new Claim(ClaimTypes.Name, credentials.Login),
                new Claim(ClaimTypes.Role, credentials.RoleName)
                }};
        var jwt = new JwtSecurityToken(
                issuer: ""CW"",
                audience: ""CW"",
                claims: claims,
                expires: DateTime.UtcNow.Add(TimeSpan.FromDays(90)),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(""J9gGkPrHnbT6rZHjkiaGLvFpRGkEMMDr"")), SecurityAlgorithms.HmacSha256));

        return new UserLoginResultServiceDto(){{
            Token = new JwtSecurityTokenHandler().WriteToken(jwt)
        }};
    }}
}}";
    }
}