
namespace Global;
public interface IPaymentMethodRepository
{
    public Task<PaymentMethodListRepositoryDto> GetAllAsync(PaymentMethodQueryRepositoryDto queryDto);

    public Task<PaymentMethodRepositoryDto> GetByIdAsync(short id);

    public Task<PaymentMethodRepositoryDto> AddAsync(AddPaymentMethodRepositoryDto addDto);

    public Task DeleteAsync(short id);

    public Task UpdateAsync(UpdatePaymentMethodRepositoryDto updateDto);
}