
using AutoMapper;
namespace Global;
public class DocumentTypeService(IDocumentTypeRepository repository,

ILogger<DocumentTypeService> logger) : IDocumentTypeService
{
    public async Task<DocumentTypeServiceDto> AddAsync(AddDocumentTypeServiceDto addServiceDto)
    {
        logger.Log(LogLevel.Debug,"Add()");
        var config = new MapperConfiguration(cfg => cfg.CreateMap<AddDocumentTypeServiceDto, AddDocumentTypeRepositoryDto>());
        var mapper = new Mapper(config);
        var addRepositoryDto = mapper.Map<AddDocumentTypeServiceDto, AddDocumentTypeRepositoryDto>(addServiceDto);
        await Task.WhenAll(
        );
        var entityRepositoryDto = await repository.AddAsync(addRepositoryDto);
        var config2 = new MapperConfiguration(cfg => cfg.CreateMap<DocumentTypeRepositoryDto, DocumentTypeServiceDto>());
        var mapper2 = new Mapper(config2);
        return mapper2.Map<DocumentTypeRepositoryDto, DocumentTypeServiceDto>(entityRepositoryDto);
    }

    public async Task DeleteAsync(short id)
    {
        logger.Log(LogLevel.Debug,"Delete()");
        await repository.DeleteAsync(id);
    }

    public async Task<DocumentTypeListServiceDto> GetAllAsync(DocumentTypeQueryServiceDto queryDto)
    {
        logger.Log(LogLevel.Debug,"GetAll()");
        var config = new MapperConfiguration(cfg => cfg.CreateMap<DocumentTypeQueryServiceDto,DocumentTypeQueryRepositoryDto>());
        var mapper = new Mapper(config);
        var dto = mapper.Map<DocumentTypeQueryServiceDto,DocumentTypeQueryRepositoryDto>(queryDto);    
        var config2 = new MapperConfiguration(cfg => cfg.CreateMap<DocumentTypeRepositoryDto,DocumentTypeServiceDto>());
        var mapper2 = new Mapper(config2);
        return new DocumentTypeListServiceDto(){
            Items = (await repository.GetAllAsync(dto)).Items.Select(x=>mapper2.Map<DocumentTypeServiceDto>(x))
        };
    }

    public async Task<DocumentTypeServiceDto> GetByIdAsync(short id)
    {
        logger.Log(LogLevel.Debug,"GetById()");
        var config = new MapperConfiguration(cfg => cfg.CreateMap<DocumentTypeRepositoryDto, DocumentTypeServiceDto>());
        var mapper = new Mapper(config);
        return mapper.Map<DocumentTypeRepositoryDto, DocumentTypeServiceDto>(await repository.GetByIdAsync(id));
    }

    public async Task UpdateAsync(UpdateDocumentTypeServiceDto updateDto)
    {
        logger.Log(LogLevel.Debug,"Update()");
        var config = new MapperConfiguration(cfg => cfg.CreateMap<UpdateDocumentTypeServiceDto, UpdateDocumentTypeRepositoryDto>());
        var mapper = new Mapper(config);
        var updateRepositoryDto = mapper.Map<UpdateDocumentTypeServiceDto, UpdateDocumentTypeRepositoryDto>(updateDto);
        await Task.WhenAll(
        );
        await repository.UpdateAsync(updateRepositoryDto);
    }
}