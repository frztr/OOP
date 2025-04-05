public interface IControllerGetById<Key, EntityControllerDto>
where Key : IComparable<Key>
{
    public abstract IResult GetById(Key id);
}
public interface IControllerGetById<Key, EntityControllerDto, EntityServiceDto> : IControllerGetById<Key, EntityControllerDto>
where EntityServiceDto : IConvertible<EntityControllerDto>
where Key : IComparable<Key>
{
    protected IServiceGetById<Key, EntityServiceDto> service { get; }
    IResult IControllerGetById<Key, EntityControllerDto>.GetById(Key id)
    {
        try
        {
            return Results.Json(service.GetById(id).Convert());
        }
        catch (Exception ex)
        {
            return Results.InternalServerError(ex);
        }
    }
}