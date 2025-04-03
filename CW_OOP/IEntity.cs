public interface IEntity{

}
public interface IEntity<K> : IEntity
{
    public K Id { get; set; }
}