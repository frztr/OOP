
using AutoMapper;
namespace Global;
using Microsoft.Extensions.Logging;
public class PaymentMethodService(IPaymentMethodRepository repository,

ILogger<PaymentMethodService> logger) : IPaymentMethodService
{
    public async Task<PaymentMethodServiceDto> AddAsync(AddPaymentMethodServiceDto addServiceDto)
    {
        logger.Log(LogLevel.Debug,"Add()");
        var config = new MapperConfiguration(cfg => cfg.CreateMap<AddPaymentMethodServiceDto, AddPaymentMethodRepositoryDto>());
        var mapper = new Mapper(config);
        var addRepositoryDto = mapper.Map<AddPaymentMethodServiceDto, AddPaymentMethodRepositoryDto>(addServiceDto);
        await Task.WhenAll(
        );
        var entityRepositoryDto = await repository.AddAsync(addRepositoryDto);
        var config2 = new MapperConfiguration(cfg => cfg.CreateMap<PaymentMethodRepositoryDto, PaymentMethodServiceDto>());
        var mapper2 = new Mapper(config2);
        return mapper2.Map<PaymentMethodRepositoryDto, PaymentMethodServiceDto>(entityRepositoryDto);
    }

    public async Task DeleteAsync(short id)
    {
        logger.Log(LogLevel.Debug,"Delete()");
        await repository.DeleteAsync(id);
    }

    public async Task<PaymentMethodListServiceDto> GetAllAsync(PaymentMethodQueryServiceDto queryDto)
    {
        logger.Log(LogLevel.Debug,"GetAll()");
        var config = new MapperConfiguration(cfg => cfg.CreateMap<PaymentMethodQueryServiceDto,PaymentMethodQueryRepositoryDto>());
        var mapper = new Mapper(config);
        var dto = mapper.Map<PaymentMethodQueryServiceDto,PaymentMethodQueryRepositoryDto>(queryDto);    
        var config2 = new MapperConfiguration(cfg => cfg.CreateMap<PaymentMethodRepositoryDto,PaymentMethodServiceDto>());
        var mapper2 = new Mapper(config2);
        return new PaymentMethodListServiceDto(){
            Items = (await repository.GetAllAsync(dto)).Items.Select(x=>mapper2.Map<PaymentMethodServiceDto>(x))
        };
    }

    public async Task<PaymentMethodServiceDto> GetByIdAsync(short id)
    {
        logger.Log(LogLevel.Debug,"GetById()");
        var config = new MapperConfiguration(cfg => cfg.CreateMap<PaymentMethodRepositoryDto, PaymentMethodServiceDto>());
        var mapper = new Mapper(config);
        return mapper.Map<PaymentMethodRepositoryDto, PaymentMethodServiceDto>(await repository.GetByIdAsync(id));
    }

    public async Task UpdateAsync(UpdatePaymentMethodServiceDto updateDto)
    {
        logger.Log(LogLevel.Debug,"Update()");
        var config = new MapperConfiguration(cfg => cfg.CreateMap<UpdatePaymentMethodServiceDto, UpdatePaymentMethodRepositoryDto>());
        var mapper = new Mapper(config);
        var updateRepositoryDto = mapper.Map<UpdatePaymentMethodServiceDto, UpdatePaymentMethodRepositoryDto>(updateDto);
        await Task.WhenAll(
        );
        await repository.UpdateAsync(updateRepositoryDto);
    }
}