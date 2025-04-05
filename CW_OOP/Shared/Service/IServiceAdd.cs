
public interface IServiceAdd<AddServiceDto>
{
    public abstract void Add(AddServiceDto addDto);
}
public interface IServiceAdd<AddServiceDto, AddRepositoryDto>
: IServiceAdd<AddServiceDto>
where AddServiceDto : IConvertible<AddRepositoryDto>
{
    protected IRepositoryAdd<AddRepositoryDto> repository { get; }

    void IServiceAdd<AddServiceDto>.Add(AddServiceDto addDto)
    {
        repository.Add(addDto.Convert());
    }
}