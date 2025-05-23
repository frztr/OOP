
namespace Global;
public interface IPaymentRepository
{
    public Task<PaymentListRepositoryDto> GetAllAsync(PaymentQueryRepositoryDto queryDto);

    public Task<PaymentRepositoryDto> GetByIdAsync(long id);

    public Task<PaymentRepositoryDto> AddAsync(AddPaymentRepositoryDto addDto);

    public Task DeleteAsync(long id);

    public Task UpdateAsync(UpdatePaymentRepositoryDto updateDto);
}