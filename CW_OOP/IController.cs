public interface IController{

}

public interface IController<K,
InAddDto,InUpdateDto> : IController
where K : IComparable<K>
where InAddDto : IDto
where InUpdateDto : IUpdateDto<K>
{
    public IResult GetAll();
    public IResult GetById(K id);

    public IResult Add(InAddDto addDto);

    public IResult Update(InUpdateDto updateDto);

    public IResult Delete(K id);
}