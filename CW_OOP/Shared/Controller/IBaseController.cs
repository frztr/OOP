using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

public interface IBaseController<Key,
AddControllerDto,
EntityControllerDto,
UpdateControllerDto> :
IControllerAdd<AddControllerDto>,
IControllerDelete<Key>,
IControllerGetAll<EntityControllerDto>,
IControllerGetById<Key, EntityControllerDto>,
IControllerUpdate<UpdateControllerDto>
where Key : IComparable<Key>
{

}
public interface IBaseController<Key,
AddControllerDto,
EntityControllerDto,
UpdateControllerDto,
AddServiceDto,
EntityServiceDto,
UpdateServiceDto> :
IBaseController<Key,
AddControllerDto,
EntityControllerDto,
UpdateControllerDto>,
IControllerAdd<AddControllerDto, AddServiceDto>,
IControllerDelete<Key>,
IControllerGetAll<EntityControllerDto, EntityServiceDto>,
IControllerGetById<Key, EntityControllerDto, EntityServiceDto>,
IControllerUpdate<UpdateControllerDto, UpdateServiceDto>
where Key : IComparable<Key>
where AddControllerDto : IConvertible<AddServiceDto>
where EntityServiceDto : IConvertible<EntityControllerDto>
where UpdateControllerDto : IConvertible<UpdateServiceDto>
{
    protected IBaseService<Key, AddServiceDto, UpdateServiceDto, EntityServiceDto> service { get; }

    IServiceAdd<AddServiceDto> IControllerAdd<AddControllerDto, AddServiceDto>.service => service;

    IServiceDelete<Key> IControllerDelete<Key>.service => service;

    IServiceGetAll<EntityServiceDto> IControllerGetAll<EntityControllerDto, EntityServiceDto>.service => service;

    IServiceUpdate<UpdateServiceDto> IControllerUpdate<UpdateControllerDto, UpdateServiceDto>.service => service;

    IServiceGetById<Key, EntityServiceDto> IControllerGetById<Key, EntityControllerDto, EntityServiceDto>.service => service;
}
[ApiController]
public abstract class BaseController<Key,
AddControllerDto,
EntityControllerDto,
UpdateControllerDto,
AddServiceDto,
EntityServiceDto,
UpdateServiceDto>
:
Controller,
IBaseController<Key,
AddControllerDto,
EntityControllerDto,
UpdateControllerDto,
AddServiceDto,
EntityServiceDto,
UpdateServiceDto>
where Key : IComparable<Key>
where AddControllerDto : IConvertible<AddServiceDto>
where EntityServiceDto : IConvertible<EntityControllerDto>
where UpdateControllerDto : IConvertible<UpdateServiceDto>
{
    private IBaseService<Key, AddServiceDto, UpdateServiceDto, EntityServiceDto> service;
    public BaseController(IBaseService<Key, AddServiceDto, UpdateServiceDto, EntityServiceDto> service)
    {
        this.service = service;
    }

    IBaseService<Key, AddServiceDto, UpdateServiceDto, EntityServiceDto> IBaseController<Key, AddControllerDto, EntityControllerDto, UpdateControllerDto, AddServiceDto, EntityServiceDto, UpdateServiceDto>.service => service;

    [HttpPost]
    [Route("add")]
    public IResult AddAction(AddControllerDto addDto) => ((IControllerAdd<AddControllerDto, AddServiceDto>)this).Add(addDto);

    [HttpGet]
    [Route("{id}")]
    public IResult GetByIdAction(Key id) => ((IControllerGetById<Key, EntityControllerDto, EntityServiceDto>)this).GetById(id);

    [HttpGet]
    [Route("")]
    public IResult GetAllAction() => ((IControllerGetAll<EntityControllerDto, EntityServiceDto>)this).GetAll();

    [HttpDelete]
    [Route("delete/{id}")]
    public IResult DeleteAction(Key id) => ((IControllerDelete<Key>)this).Delete(id);

    [HttpPatch]
    [Route("update")]
    public IResult UpdateAction(UpdateControllerDto updateDto) => ((IControllerUpdate<UpdateControllerDto, UpdateServiceDto>)this).Update(updateDto);
}