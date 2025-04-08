
using AutoMapper;
using Microsoft.EntityFrameworkCore;
namespace Global;
public class DocumentTypeRepository(AppDbContext db) : IDocumentTypeRepository
{ 
    DbSet<DocumentType> set = db.Set<DocumentType>();
    public async Task<DocumentTypeRepositoryDto> AddAsync(AddDocumentTypeRepositoryDto addDto)
    {  
        var config = new MapperConfiguration(cfg => cfg.CreateMap<AddDocumentTypeRepositoryDto, DocumentType>());
        var mapper = new Mapper(config);
        var entity = mapper.Map<AddDocumentTypeRepositoryDto, DocumentType>(addDto);
        await set.AddAsync(entity);
        await db.SaveChangesAsync();
        var config2 = new MapperConfiguration(cfg => cfg.CreateMap<DocumentType,DocumentTypeRepositoryDto>());
        var mapper2 = new Mapper(config2);
        var dto = mapper2.Map<DocumentType,DocumentTypeRepositoryDto>(entity);
        return dto;
    }

    public async Task DeleteAsync(short id)
    {
        set.Remove(await set.FirstOrDefaultAsync(x => x.Id == id));
        await db.SaveChangesAsync();
    }

    public async Task<DocumentTypeListRepositoryDto> GetAllAsync(short count = 50, short offset = 0)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<DocumentType,DocumentTypeRepositoryDto>());
        var mapper = new Mapper(config);
        return new DocumentTypeListRepositoryDto()
        {
            Items = mapper.Map<List<DocumentTypeRepositoryDto>>(
            await set.Skip(offset).Take(count < 50 ? count : 50).ToListAsync()
            )
        };
    }

    public async Task<DocumentTypeRepositoryDto> GetByIdAsync(short id)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<DocumentType,DocumentTypeRepositoryDto>());
        var mapper = new Mapper(config);
        var entity = await set.FirstOrDefaultAsync(x => x.Id == id);
        return mapper.Map<DocumentType,DocumentTypeRepositoryDto>(entity);
    }

    public async Task UpdateAsync(UpdateDocumentTypeRepositoryDto updateDto)
    {
        var entity = await set.FirstOrDefaultAsync(x => x.Id == updateDto.Id);
        var config = new MapperConfiguration(cfg => cfg.CreateMap<UpdateDocumentTypeRepositoryDto, DocumentType>());
        var mapper = new Mapper(config);
        mapper.Map<UpdateDocumentTypeRepositoryDto, DocumentType>(updateDto,entity);
        db.SaveChangesAsync();
    }
}