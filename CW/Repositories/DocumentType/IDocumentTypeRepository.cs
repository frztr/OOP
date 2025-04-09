
        namespace Global;
        public interface IDocumentTypeRepository
{
    public Task<DocumentTypeListRepositoryDto> GetAllAsync(DocumentTypeQueryRepositoryDto queryDto);

    public Task<DocumentTypeRepositoryDto> GetByIdAsync(short id);

    public Task<DocumentTypeRepositoryDto> AddAsync(AddDocumentTypeRepositoryDto addDto);

    public Task DeleteAsync(short id);

    public Task UpdateAsync(UpdateDocumentTypeRepositoryDto updateDto);
}