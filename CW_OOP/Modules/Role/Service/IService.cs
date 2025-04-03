namespace Role;

public interface IService
{
    public IEnumerable<DTO.EntityDto> GetAll();

    public DTO.EntityDto GetById(short id);

    public void Add(DTO.AddDto addDto);

    public void Delete(short id);

    public void Update(DTO.UpdateDto updateDto);
}
