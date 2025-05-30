
namespace Global;
public interface IMessageService
{
    public Task<MessageListServiceDto> GetAllAsync(MessageQueryServiceDto queryDto);

    public Task<MessageServiceDto> GetByIdAsync(long id);

    public Task<MessageServiceDto> AddAsync(AddMessageServiceDto addDto);

    public Task DeleteAsync(long id);

    public Task UpdateAsync(UpdateMessageServiceDto updateDto);
}