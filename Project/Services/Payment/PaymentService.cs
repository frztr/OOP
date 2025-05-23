
using AutoMapper;
namespace Global;
using Microsoft.Extensions.Logging;
public class PaymentService(IPaymentRepository repository,
IBookingRepository bookingRepository,
IPaymentMethodRepository paymentMethodRepository,
IPaymentStatusRepository paymentStatusRepository,
ILogger<PaymentService> logger) : IPaymentService
{
    public async Task<PaymentServiceDto> AddAsync(AddPaymentServiceDto addServiceDto)
    {
        logger.Log(LogLevel.Debug,"Add()");
        var config = new MapperConfiguration(cfg => cfg.CreateMap<AddPaymentServiceDto, AddPaymentRepositoryDto>());
        var mapper = new Mapper(config);
        var addRepositoryDto = mapper.Map<AddPaymentServiceDto, AddPaymentRepositoryDto>(addServiceDto);
        await Task.WhenAll(
        bookingRepository.GetByIdAsync(addRepositoryDto.BookingId),
		paymentMethodRepository.GetByIdAsync(addRepositoryDto.PaymentMethodId),
		paymentStatusRepository.GetByIdAsync(addRepositoryDto.StatusId));
        var entityRepositoryDto = await repository.AddAsync(addRepositoryDto);
        var config2 = new MapperConfiguration(cfg => cfg.CreateMap<PaymentRepositoryDto, PaymentServiceDto>());
        var mapper2 = new Mapper(config2);
        return mapper2.Map<PaymentRepositoryDto, PaymentServiceDto>(entityRepositoryDto);
    }

    public async Task DeleteAsync(long id)
    {
        logger.Log(LogLevel.Debug,"Delete()");
        await repository.DeleteAsync(id);
    }

    public async Task<PaymentListServiceDto> GetAllAsync(PaymentQueryServiceDto queryDto)
    {
        logger.Log(LogLevel.Debug,"GetAll()");
        var config = new MapperConfiguration(cfg => cfg.CreateMap<PaymentQueryServiceDto,PaymentQueryRepositoryDto>());
        var mapper = new Mapper(config);
        var dto = mapper.Map<PaymentQueryServiceDto,PaymentQueryRepositoryDto>(queryDto);    
        var config2 = new MapperConfiguration(cfg => cfg.CreateMap<PaymentRepositoryDto,PaymentServiceDto>());
        var mapper2 = new Mapper(config2);
        return new PaymentListServiceDto(){
            Items = (await repository.GetAllAsync(dto)).Items.Select(x=>mapper2.Map<PaymentServiceDto>(x))
        };
    }

    public async Task<PaymentServiceDto> GetByIdAsync(long id)
    {
        logger.Log(LogLevel.Debug,"GetById()");
        var config = new MapperConfiguration(cfg => cfg.CreateMap<PaymentRepositoryDto, PaymentServiceDto>());
        var mapper = new Mapper(config);
        return mapper.Map<PaymentRepositoryDto, PaymentServiceDto>(await repository.GetByIdAsync(id));
    }

    public async Task UpdateAsync(UpdatePaymentServiceDto updateDto)
    {
        logger.Log(LogLevel.Debug,"Update()");
        var config = new MapperConfiguration(cfg => cfg.CreateMap<UpdatePaymentServiceDto, UpdatePaymentRepositoryDto>());
        var mapper = new Mapper(config);
        var updateRepositoryDto = mapper.Map<UpdatePaymentServiceDto, UpdatePaymentRepositoryDto>(updateDto);
        await Task.WhenAll(
        updateDto.BookingId.HasValue ? bookingRepository.GetByIdAsync(updateDto.BookingId.Value) : Task.CompletedTask,
		updateDto.PaymentMethodId.HasValue ? paymentMethodRepository.GetByIdAsync(updateDto.PaymentMethodId.Value) : Task.CompletedTask,
		updateDto.StatusId.HasValue ? paymentStatusRepository.GetByIdAsync(updateDto.StatusId.Value) : Task.CompletedTask);
        await repository.UpdateAsync(updateRepositoryDto);
    }
}