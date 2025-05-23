
using AutoMapper;
namespace Global;
using Microsoft.Extensions.Logging;
public class PaymentStatusService(IPaymentStatusRepository repository,

ILogger<PaymentStatusService> logger) : IPaymentStatusService
{
    public async Task<PaymentStatusServiceDto> AddAsync(AddPaymentStatusServiceDto addServiceDto)
    {
        logger.Log(LogLevel.Debug,"Add()");
        var config = new MapperConfiguration(cfg => cfg.CreateMap<AddPaymentStatusServiceDto, AddPaymentStatusRepositoryDto>());
        var mapper = new Mapper(config);
        var addRepositoryDto = mapper.Map<AddPaymentStatusServiceDto, AddPaymentStatusRepositoryDto>(addServiceDto);
        await Task.WhenAll(
        );
        var entityRepositoryDto = await repository.AddAsync(addRepositoryDto);
        var config2 = new MapperConfiguration(cfg => cfg.CreateMap<PaymentStatusRepositoryDto, PaymentStatusServiceDto>());
        var mapper2 = new Mapper(config2);
        return mapper2.Map<PaymentStatusRepositoryDto, PaymentStatusServiceDto>(entityRepositoryDto);
    }

    public async Task DeleteAsync(short id)
    {
        logger.Log(LogLevel.Debug,"Delete()");
        await repository.DeleteAsync(id);
    }

    public async Task<PaymentStatusListServiceDto> GetAllAsync(PaymentStatusQueryServiceDto queryDto)
    {
        logger.Log(LogLevel.Debug,"GetAll()");
        var config = new MapperConfiguration(cfg => cfg.CreateMap<PaymentStatusQueryServiceDto,PaymentStatusQueryRepositoryDto>());
        var mapper = new Mapper(config);
        var dto = mapper.Map<PaymentStatusQueryServiceDto,PaymentStatusQueryRepositoryDto>(queryDto);    
        var config2 = new MapperConfiguration(cfg => cfg.CreateMap<PaymentStatusRepositoryDto,PaymentStatusServiceDto>());
        var mapper2 = new Mapper(config2);
        return new PaymentStatusListServiceDto(){
            Items = (await repository.GetAllAsync(dto)).Items.Select(x=>mapper2.Map<PaymentStatusServiceDto>(x))
        };
    }

    public async Task<PaymentStatusServiceDto> GetByIdAsync(short id)
    {
        logger.Log(LogLevel.Debug,"GetById()");
        var config = new MapperConfiguration(cfg => cfg.CreateMap<PaymentStatusRepositoryDto, PaymentStatusServiceDto>());
        var mapper = new Mapper(config);
        return mapper.Map<PaymentStatusRepositoryDto, PaymentStatusServiceDto>(await repository.GetByIdAsync(id));
    }

    public async Task UpdateAsync(UpdatePaymentStatusServiceDto updateDto)
    {
        logger.Log(LogLevel.Debug,"Update()");
        var config = new MapperConfiguration(cfg => cfg.CreateMap<UpdatePaymentStatusServiceDto, UpdatePaymentStatusRepositoryDto>());
        var mapper = new Mapper(config);
        var updateRepositoryDto = mapper.Map<UpdatePaymentStatusServiceDto, UpdatePaymentStatusRepositoryDto>(updateDto);
        await Task.WhenAll(
        );
        await repository.UpdateAsync(updateRepositoryDto);
    }
}