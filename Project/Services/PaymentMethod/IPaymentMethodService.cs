
namespace Global;
public interface IPaymentMethodService
{
    public Task<PaymentMethodListServiceDto> GetAllAsync(PaymentMethodQueryServiceDto queryDto);

    public Task<PaymentMethodServiceDto> GetByIdAsync(short id);

    public Task<PaymentMethodServiceDto> AddAsync(AddPaymentMethodServiceDto addDto);

    public Task DeleteAsync(short id);

    public Task UpdateAsync(UpdatePaymentMethodServiceDto updateDto);
}