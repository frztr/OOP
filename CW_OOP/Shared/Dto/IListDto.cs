public interface IListDto<EntityDto>
{
    public IEnumerable<EntityDto> items { get; set; }
}