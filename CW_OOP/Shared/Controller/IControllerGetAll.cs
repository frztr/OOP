using Newtonsoft.Json;

public interface IControllerGetAll<EntityControllerDto>
{
    public abstract IResult GetAll();
}
public interface IControllerGetAll<EntityControllerDto, EntityServiceDto>
: IControllerGetAll<EntityControllerDto>
where EntityServiceDto : IConvertible<EntityControllerDto>
{
    protected IServiceGetAll<EntityServiceDto> service { get; }
    IResult IControllerGetAll<EntityControllerDto>.GetAll()
    {
        try
        {
            return Results.Json(service.GetAll().Select(x => x.Convert()));
        }
        catch (Exception ex)
        {
            return Results.InternalServerError(ex);
        }
    }
}