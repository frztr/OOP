
namespace Global;
public interface IPaymentService
{
    public Task<PaymentListServiceDto> GetAllAsync(PaymentQueryServiceDto queryDto);

    public Task<PaymentServiceDto> GetByIdAsync(long id);

    public Task<PaymentServiceDto> AddAsync(AddPaymentServiceDto addDto);

    public Task DeleteAsync(long id);

    public Task UpdateAsync(UpdatePaymentServiceDto updateDto);
}