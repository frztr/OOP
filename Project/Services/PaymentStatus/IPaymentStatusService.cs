
namespace Global;
public interface IPaymentStatusService
{
    public Task<PaymentStatusListServiceDto> GetAllAsync(PaymentStatusQueryServiceDto queryDto);

    public Task<PaymentStatusServiceDto> GetByIdAsync(short id);

    public Task<PaymentStatusServiceDto> AddAsync(AddPaymentStatusServiceDto addDto);

    public Task DeleteAsync(short id);

    public Task UpdateAsync(UpdatePaymentStatusServiceDto updateDto);
}