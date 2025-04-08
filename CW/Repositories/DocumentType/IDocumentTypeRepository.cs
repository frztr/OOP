
        namespace Global;
        public interface IDocumentTypeRepository
{
    public Task<DocumentTypeListRepositoryDto> GetAllAsync(short count = 50, short offset = 0);

    public Task<DocumentTypeRepositoryDto> GetByIdAsync(short id);

    public Task<DocumentTypeRepositoryDto> AddAsync(AddDocumentTypeRepositoryDto addDto);

    public Task DeleteAsync(short id);

    public Task UpdateAsync(UpdateDocumentTypeRepositoryDto updateDto);
}