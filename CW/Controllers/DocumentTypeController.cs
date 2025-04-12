
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
using Microsoft.AspNetCore.Mvc;
namespace Global;
[Authorize(Roles="admin")]
[ApiController]
[Route("DocumentType")]
public class DocumentTypeController(IDocumentTypeService service) : Controller
{
    [HttpPost]
    [Route("add")]
    [ProducesResponseType(200)]
    [ProducesResponseType(500)]
    public async Task<IResult> Add(AddDocumentTypeControllerDto addDto) 
    {
        try
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<AddDocumentTypeControllerDto, AddDocumentTypeServiceDto>());
            var mapper = new Mapper(config);
            var addServiceDto = mapper.Map<AddDocumentTypeControllerDto, AddDocumentTypeServiceDto>(addDto);
            var result = await service.AddAsync(addServiceDto);
            var config2 = new MapperConfiguration(cfg => cfg.CreateMap<DocumentTypeServiceDto, DocumentTypeControllerDto>());
            var mapper2 = new Mapper(config2);
            return Results.Json(mapper2.Map<DocumentTypeServiceDto, DocumentTypeControllerDto>(result));
        }
        catch (Exception ex)
        {
            return Results.InternalServerError(new {error = ex.Message});
        }
    }

    [HttpDelete]
    [Route("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(500)]
    public async Task<IResult> Delete(short id)
    {
        try
        {
            await service.DeleteAsync(id);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.InternalServerError(new {error = ex.Message}); 
        }
    }

    [HttpGet]
    [Route("")]
    [ProducesResponseType(200)]
    [ProducesResponseType(500)]
    public async Task<IResult> GetAll([FromQuery]DocumentTypeQueryControllerDto queryDto)
    {
        try
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<DocumentTypeQueryControllerDto,DocumentTypeQueryServiceDto>());
            var mapper = new Mapper(config);
            var dto = mapper.Map<DocumentTypeQueryControllerDto,DocumentTypeQueryServiceDto>(queryDto);
            var config2 = new MapperConfiguration(cfg => cfg.CreateMap<DocumentTypeServiceDto,DocumentTypeControllerDto>());
            var mapper2 = new Mapper(config2);
            return Results.Json(new DocumentTypeListControllerDto(){
                Items = (await service.GetAllAsync(dto)).Items.Select(x=>mapper2.Map<DocumentTypeServiceDto,DocumentTypeControllerDto>(x))
            });
        }
        catch (Exception ex)
        {
            return Results.InternalServerError(new {error = ex.Message});
        }
    }

    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(500)]
    public async Task<IResult> GetById(short id)
    {
        try
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<DocumentTypeServiceDto, DocumentTypeControllerDto>());
            var mapper = new Mapper(config);
            return Results.Json(mapper.Map<DocumentTypeServiceDto, DocumentTypeControllerDto>(await service.GetByIdAsync(id)));
        }
        catch (Exception ex)
        {
            return Results.InternalServerError(new {error = ex.Message});
        }
    }
    [HttpPatch]
    [Route("update")]
    [ProducesResponseType(200)]
    [ProducesResponseType(500)]
    public async Task<IResult> UpdateAsync(UpdateDocumentTypeControllerDto updateDto)
    {
        try
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<UpdateDocumentTypeControllerDto, UpdateDocumentTypeServiceDto>());
            var mapper = new Mapper(config);
            var updateServiceDto = mapper.Map<UpdateDocumentTypeControllerDto, UpdateDocumentTypeServiceDto>(updateDto);
            await service.UpdateAsync(updateServiceDto);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.InternalServerError(new {error = ex.Message});
        }
    }
}
