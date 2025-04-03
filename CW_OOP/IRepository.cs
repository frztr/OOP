public interface IRepository{
    
}

public interface IRepository<K,InAddDto, InUpdateDto, InEntityDto> : IRepository
where K : IComparable<K>
where InAddDto : IDto
where InUpdateDto : IUpdateDto<K>
where InEntityDto : IDto
{
    public IEnumerable<InEntityDto> GetAll();
    public InEntityDto GetById(K id);

    public void Add(InAddDto addDto);

    public void Update(InUpdateDto updateDto);

    public void Delete(K id);
}