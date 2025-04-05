public interface IControllerUpdate<UpdateControllerDto>
{
    public abstract IResult Update(UpdateControllerDto updateDto);
}
public interface IControllerUpdate<UpdateControllerDto, UpdateServiceDto>
: IControllerUpdate<UpdateControllerDto>
where UpdateControllerDto : IConvertible<UpdateServiceDto>
{
    public IServiceUpdate<UpdateServiceDto> service { get; }
    IResult IControllerUpdate<UpdateControllerDto>.Update(UpdateControllerDto updateDto)
    {
        try
        {
            service.Update(updateDto.Convert());
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.InternalServerError(ex);
        }
    }
}