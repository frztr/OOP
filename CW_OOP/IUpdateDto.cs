public interface IUpdateDto<Key> : IDto where Key : IComparable<Key>
{
    public Key Id { get; set; }
}