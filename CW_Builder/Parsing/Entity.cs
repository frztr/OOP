public class Entity
{
    public string Name { get; set; }

    public List<EntityProp> Props { get; set; } = new List<EntityProp>();

    public bool ExtendedSearch { get; set; } = false;
}