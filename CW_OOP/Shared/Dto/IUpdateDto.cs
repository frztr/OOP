public interface IUpdateDto<Key,Entity> : IDto where Key : IComparable<Key>
{
    public Key Id { get; set; }

    public void Update(Entity entity);
}