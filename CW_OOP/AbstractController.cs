
// using Microsoft.AspNetCore.Mvc;

// public abstract class AbstractController<K,
// InAddDto, InUpdateDto, InEntityDto,
// OutAddDto, OutUpdateDto, OutEntityDto
// >(
//     IService<K, OutAddDto, OutUpdateDto, OutEntityDto> service
//     // AbstractConverter<InAddDto, OutAddDto> addConverter,
//     // AbstractConverter<InUpdateDto, OutUpdateDto> updateConverter,
//     // AbstractConverter<OutEntityDto, InEntityDto> entityConverter
// ) : Controller, IController<K, InAddDto, InUpdateDto>
// where K : IComparable<K>
// where InAddDto : IDto
// where InUpdateDto : IUpdateDto<K>
// where InEntityDto : IDto
// where OutAddDto : IDto
// where OutUpdateDto : IUpdateDto<K>
// where OutEntityDto : IDto
// {
//     [HttpPost]
//     [Route("add")]
//     public virtual IResult Add(InAddDto dto)
//     {
//         try
//         {
//             service.Add(dto.Cast<OutAddDto>());
//             // service.Add(addConverter.Convert(dto));
//             return Results.Created();
//         }
//         catch (Exception ex)
//         {
//             return Results.InternalServerError(ex);
//         }
//     }
    
//     [HttpGet]
//     public virtual IResult GetAll()
//     {
//         try
//         {
//             return Results.Json(service.GetAll().Select(x => x.Cast<InEntityDto>()));
//             // return Results.Json(service.GetAll().Select(x => entityConverter.Convert(x)));
//         }
//         catch (Exception ex)
//         {
//             return Results.InternalServerError(ex);
//         }
//     }
//     [HttpGet]
//     [Route("{id}")]
//     public virtual IResult GetById(K id)
//     {
//         try
//         {
//             return Results.Json(service.GetById(id).Cast<InEntityDto>());
//             // return Results.Json(entityConverter.Convert(service.GetById(id)));
//         }
//         catch (Exception ex)
//         {
//             return Results.InternalServerError(ex);
//         }
//     }
//     [HttpDelete]
//     [Route("delete/{id}")]
//     public virtual IResult Delete(K id)
//     {
//         try
//         {
//             service.Delete(id);
//             return Results.Ok();
//         }
//         catch (Exception ex)
//         {
//             return Results.InternalServerError(ex);
//         }
//     }
//     [HttpPatch]
//     [Route("update")]
//     public virtual IResult Update(InUpdateDto dto)
//     {
//         try
//         {
//             service.Update(dto.Cast<OutUpdateDto>());
//             return Results.Ok();
//         }
//         catch (Exception ex)
//         {
//             return Results.InternalServerError(ex);
//         }
//     }
// }