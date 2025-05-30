
namespace Global;
public interface IMessageRepository
{
    public Task<MessageListRepositoryDto> GetAllAsync(MessageQueryRepositoryDto queryDto);

    public Task<MessageRepositoryDto> GetByIdAsync(long id);

    public Task<MessageRepositoryDto> AddAsync(AddMessageRepositoryDto addDto);

    public Task DeleteAsync(long id);

    public Task UpdateAsync(UpdateMessageRepositoryDto updateDto);
}