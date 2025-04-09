
namespace Global;
public interface IDocumentTypeService
    {
        public Task<DocumentTypeListServiceDto> GetAllAsync(DocumentTypeQueryServiceDto queryDto);

        public Task<DocumentTypeServiceDto> GetByIdAsync(short id);

        public Task<DocumentTypeServiceDto> AddAsync(AddDocumentTypeServiceDto addDto);

        public Task DeleteAsync(short id);

        public Task UpdateAsync(UpdateDocumentTypeServiceDto updateDto);
    }