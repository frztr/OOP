
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
namespace Global;
[ApiController]
[Route("DocumentType")]
public class DocumentTypeController(IDocumentTypeService service)
{
    [HttpPost]
    [Route("add")]
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

    [HttpGet]
    [Route("")]
    public async Task<IResult> GetAll(short count = 50, short offset = 0)
    {
        try
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<DocumentTypeServiceDto,DocumentTypeControllerDto>());
            var mapper = new Mapper(config);
            return Results.Json(new DocumentTypeListControllerDto(){
                Items = (await service.GetAllAsync(count,offset)).Items.Select(x=>mapper.Map<DocumentTypeServiceDto,DocumentTypeControllerDto>(x))
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
            var config = new MapperConfiguration(cfg => cfg.CreateMap<DocumentTypeServiceDto, DocumentTypeControllerDto>());
            var mapper = new Mapper(config);
            return Results.Json(mapper.Map<DocumentTypeServiceDto, DocumentTypeControllerDto>(await service.GetByIdAsync(id)));
        }
        catch (Exception ex)
        {
            return Results.InternalServerError(ex);
        }
    }
    [HttpPatch]
    [Route("update")]
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
            return Results.InternalServerError(ex);
        }
    }
}
