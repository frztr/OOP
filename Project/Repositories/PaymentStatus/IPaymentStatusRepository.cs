
namespace Global;
public interface IPaymentStatusRepository
{
    public Task<PaymentStatusListRepositoryDto> GetAllAsync(PaymentStatusQueryRepositoryDto queryDto);

    public Task<PaymentStatusRepositoryDto> GetByIdAsync(short id);

    public Task<PaymentStatusRepositoryDto> AddAsync(AddPaymentStatusRepositoryDto addDto);

    public Task DeleteAsync(short id);

    public Task UpdateAsync(UpdatePaymentStatusRepositoryDto updateDto);
}