public interface IControllerDelete<Key>
where Key : IComparable<Key>
{
    IServiceDelete<Key> service { get; }
    public IResult Delete(Key id)
    {
        try
        {
            service.Delete(id);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.InternalServerError(ex);
        }
    }

}