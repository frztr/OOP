public interface IServiceUpdate<UpdateServiceDto>
{
    public abstract void Update(UpdateServiceDto updateDto);
}
public interface IServiceUpdate<UpdateServiceDto, UpdateRepositoryDto>
: IServiceUpdate<UpdateServiceDto>
where UpdateServiceDto : IConvertible<UpdateRepositoryDto>
{
    public IRepositoryUpdate<UpdateRepositoryDto> repository { get; }
    void IServiceUpdate<UpdateServiceDto>.Update(UpdateServiceDto updateDto)
    {
        repository.Update(updateDto.Convert());
    }
}