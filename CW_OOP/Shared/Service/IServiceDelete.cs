public interface IServiceDelete<Key>
where Key : IComparable<Key>
{ 
    IRepositoryDelete<Key> repository {get;}
    public void Delete(Key id)
    {
        repository.Delete(id);
    }
}