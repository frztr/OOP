
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
namespace Global;
[ApiController]
[Route("User")]
public class UserController(IUserService service)
{
    [HttpPost]
    [Route("add")]
    public async Task<IResult> Add(AddUserControllerDto addDto)
    {
        try
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<AddUserControllerDto, AddUserServiceDto>());
            var mapper = new Mapper(config);
            var addServiceDto = mapper.Map<AddUserControllerDto, AddUserServiceDto>(addDto);
            var result = await service.AddAsync(addServiceDto);
            var config2 = new MapperConfiguration(cfg => cfg.CreateMap<UserServiceDto, UserControllerDto>());
            var mapper2 = new Mapper(config2);
            return Results.Json(mapper2.Map<UserServiceDto, UserControllerDto>(result));
        }
        catch (Exception ex)
        {
            return Results.InternalServerError(ex);
        }
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<IResult> Delete(short id)
    {
        try
        {
            await service.DeleteAsync(id);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.InternalServerError(ex);
        }
    }
    [Authorize]
    [HttpGet]
    [Route("")]
    public async Task<IResult> GetAll(short count = 50, short offset = 0)
    {
        try
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<UserServiceDto,UserControllerDto>());
            var mapper = new Mapper(config);
            return Results.Json(new UserListControllerDto(){
                Items = (await service.GetAllAsync(count,offset)).Items.Select(x=>mapper.Map<UserControllerDto>(x))
            });
        }
        catch (Exception ex)
        {
            return Results.InternalServerError(ex);
        }
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IResult> GetById(short id)
    {
        try
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<UserServiceDto, UserControllerDto>());
            var mapper = new Mapper(config);
            return Results.Json(mapper.Map<UserServiceDto, UserControllerDto>(await service.GetByIdAsync(id)));
        }
        catch (Exception ex)
        {
            return Results.InternalServerError(ex);
        }
    }
    [HttpPatch]
    [Route("update")]
    public async Task<IResult> UpdateAsync(UpdateUserControllerDto updateDto)
    {
        try
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<UpdateUserControllerDto, UpdateUserServiceDto>());
            var mapper = new Mapper(config);
            var updateServiceDto = mapper.Map<UpdateUserControllerDto, UpdateUserServiceDto>(updateDto);
            await service.UpdateAsync(updateServiceDto);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.InternalServerError(ex);
        }
    }

    [HttpPost]
    [Route("login")]
    public async Task<IResult> Login(UserLoginControllerDto loginDto)
    {
        try
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<UserLoginControllerDto, UserLoginServiceDto>());
            var mapper = new Mapper(config);
            var userLoginServiceDto = mapper.Map<UserLoginControllerDto, UserLoginServiceDto>(loginDto);
            
            var config2 = new MapperConfiguration(cfg => cfg.CreateMap<UserLoginResultServiceDto, UserLoginResultControllerDto>());
            var mapper2 = new Mapper(config2);
            return Results.Json(mapper2.Map<UserLoginResultServiceDto, UserLoginResultControllerDto>(await service.Login(userLoginServiceDto)));
            
        }
        catch (Exception ex)
        {
            return Results.InternalServerError(ex);
        }
    }
}
