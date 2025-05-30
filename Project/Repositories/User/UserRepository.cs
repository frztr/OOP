
using AutoMapper;
using Microsoft.EntityFrameworkCore;
namespace Global;
public class UserRepository(AppDbContext db) : IUserRepository
{ 
    DbSet<User> set = db.Set<User>();
    public async Task<UserRepositoryDto> AddAsync(AddUserRepositoryDto addDto)
    {  
        var config = new MapperConfiguration(cfg => cfg.CreateMap<AddUserRepositoryDto, User>());
        var mapper = new Mapper(config);
        var entity = mapper.Map<AddUserRepositoryDto, User>(addDto);
        await set.AddAsync(entity);
        await db.SaveChangesAsync();
        var config2 = new MapperConfiguration(cfg => cfg.CreateMap<User,UserRepositoryDto>());
        var mapper2 = new Mapper(config2);
        var dto = mapper2.Map<User,UserRepositoryDto>(entity);
        return dto;
    }

    public async Task DeleteAsync(long id)
    {
        var entity = await set.FirstOrDefaultAsync(x => x.Id == id);
        if(entity == null) throw new EntityNotFoundException<User>(new {id});
        set.Remove(entity);
        await db.SaveChangesAsync();
    }

    public async Task<UserListRepositoryDto> GetAllAsync(UserQueryRepositoryDto queryDto)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<User,UserRepositoryDto>());
        var mapper = new Mapper(config);
        return new UserListRepositoryDto()
        {
            Items = mapper.Map<List<UserRepositoryDto>>(
            await set.Skip(queryDto.Offset).Take(queryDto.Count < 50 ? queryDto.Count : 50).ToListAsync()
            )
        };
    }

    public async Task<UserRepositoryDto> GetByIdAsync(long id)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<User,UserRepositoryDto>());
        var mapper = new Mapper(config);
        var entity = await set.FirstOrDefaultAsync(x => x.Id == id);
        if(entity == null) throw new EntityNotFoundException<User>(new {id});
        return mapper.Map<User,UserRepositoryDto>(entity);
    }

    public async Task UpdateAsync(UpdateUserRepositoryDto updateDto)
    {
        var entity = await set.FirstOrDefaultAsync(x => x.Id == updateDto.Id);
        if(entity == null) throw new EntityNotFoundException<User>(new {Id = updateDto.Id});
        		if(!String.IsNullOrEmpty(updateDto.Login)){
            entity.Login = updateDto.Login;
        }
		if(!String.IsNullOrEmpty(updateDto.Email)){
            entity.Email = updateDto.Email;
        }
		if(!String.IsNullOrEmpty(updateDto.PasswordHash)){
            entity.PasswordHash = updateDto.PasswordHash;
        }
		if(!String.IsNullOrEmpty(updateDto.Firstname)){
            entity.Firstname = updateDto.Firstname;
        }
		if(!String.IsNullOrEmpty(updateDto.Lastname)){
            entity.Lastname = updateDto.Lastname;
        }

		if(!String.IsNullOrEmpty(updateDto.Bio)){
            entity.Bio = updateDto.Bio;
        }


		if(updateDto.RoleId.HasValue){
            entity.RoleId = updateDto.RoleId.Value;
        }

		if(!String.IsNullOrEmpty(updateDto.WebsiteUrl)){
            entity.WebsiteUrl = updateDto.WebsiteUrl;
        }
		if(!String.IsNullOrEmpty(updateDto.AvatarUrl)){
            entity.AvatarUrl = updateDto.AvatarUrl;
        }












        await db.SaveChangesAsync();
    }

    public async Task<UserLoginResultRepositoryDto> Login(UserLoginRepositoryDto loginDto)
    {
        var entity = await set.Include(x=>x.Role).FirstOrDefaultAsync(x=>x.Login == loginDto.Login && x.PasswordHash == loginDto.PasswordHash);
        if(entity == null) throw new BadLoginException();
        var config = new MapperConfiguration(cfg => cfg.CreateMap<User, UserLoginResultRepositoryDto>());
        var mapper = new Mapper(config);
        var resultDto = mapper.Map<User, UserLoginResultRepositoryDto>(entity);
        resultDto.RoleName = entity.Role.Name;
        return resultDto;
    }
}