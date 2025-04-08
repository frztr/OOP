
using AutoMapper;
namespace Global;
public class DocumentTypeService(IDocumentTypeRepository repository) : IDocumentTypeService
{
    public async Task<DocumentTypeServiceDto> AddAsync(AddDocumentTypeServiceDto addServiceDto)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<AddDocumentTypeServiceDto, AddDocumentTypeRepositoryDto>());
        var mapper = new Mapper(config);
        var addRepositoryDto = mapper.Map<AddDocumentTypeServiceDto, AddDocumentTypeRepositoryDto>(addServiceDto);
        var entityRepositoryDto = await repository.AddAsync(addRepositoryDto);
        var config2 = new MapperConfiguration(cfg => cfg.CreateMap<DocumentTypeRepositoryDto, DocumentTypeServiceDto>());
        var mapper2 = new Mapper(config2);
        return mapper2.Map<DocumentTypeRepositoryDto, DocumentTypeServiceDto>(entityRepositoryDto);
    }

    public async Task DeleteAsync(short id)
    {
        await repository.DeleteAsync(id);
    }

    public async Task<DocumentTypeListServiceDto> GetAllAsync(short count = 50, short offset = 0)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<DocumentTypeRepositoryDto,DocumentTypeServiceDto>());
        var mapper = new Mapper(config);
        return new DocumentTypeListServiceDto(){
            Items = (await repository.GetAllAsync(count, offset)).Items.Select(x=>mapper.Map<DocumentTypeServiceDto>(x))
        };
    }

    public async Task<DocumentTypeServiceDto> GetByIdAsync(short id)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<DocumentTypeRepositoryDto, DocumentTypeServiceDto>());
        var mapper = new Mapper(config);
        return mapper.Map<DocumentTypeRepositoryDto, DocumentTypeServiceDto>(await repository.GetByIdAsync(id));
    }

    public async Task UpdateAsync(UpdateDocumentTypeServiceDto updateDto)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<UpdateDocumentTypeServiceDto, UpdateDocumentTypeRepositoryDto>());
        var mapper = new Mapper(config);
        var updateRepositoryDto = mapper.Map<UpdateDocumentTypeServiceDto, UpdateDocumentTypeRepositoryDto>(updateDto);
        await repository.UpdateAsync(updateRepositoryDto);
    }
}