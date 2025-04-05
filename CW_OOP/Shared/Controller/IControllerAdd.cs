using Microsoft.AspNetCore.Components;

public interface IControllerAdd<AddControllerDto>
{
    public IResult Add(AddControllerDto addDto);
}
public interface IControllerAdd<AddControllerDto, AddServiceDto> : IControllerAdd<AddControllerDto>
where AddControllerDto : IConvertible<AddServiceDto>
{
    protected IServiceAdd<AddServiceDto> service { get; }

    IResult IControllerAdd<AddControllerDto>.Add(AddControllerDto addDto)
    {
        try
        {
            service.Add(addDto.Convert());
            return Results.Created();
        }
        catch (Exception ex)
        {
            return Results.InternalServerError(ex);
        }
    }
}